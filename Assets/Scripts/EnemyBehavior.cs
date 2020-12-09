using UnityEngine;
using Pathfinding;
using UnityEditor;
using System;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target;
    public float speed = 400f;
    public float nextWaypointDistance = 5f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rigidbody2d;
    Transform transform;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {

        GameObject player = GameObject.Find("player");

        if(player != null)
        {
            target = player.GetComponent<Transform>();
        } 

        rigidbody2d = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();


        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        print(target.position);

        if(seeker.IsDone())
            seeker.StartPath(rigidbody2d.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rigidbody2d.position).normalized;
        if (direction.x > 0)
            transform.localScale = new Vector3(0.15f, 0.15f, 1f);
        else if (direction.x < 0)
            transform.localScale = new Vector3(-0.15f, 0.15f, 1f);
        Vector2 force = direction * speed * Time.deltaTime;

        rigidbody2d.AddForce(force);

        float distance = Vector2.Distance(rigidbody2d.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //if(other.gameObject.GetType)
        if (other.gameObject.name == "player" && !animator.GetBool("isAttacking"))
        {
            animator.SetBool("isAttacking", true);
            PlayerController controller = other.gameObject.GetComponent<PlayerController>();

            if (controller != null)
            {
                controller.ChangeHealth(-1);
            }
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        OnCollisionEnter2D(other);
    }

    void EndAttack()
    {
        animator.SetBool("isAttacking", false);
    }

    public void Die()
    {
        animator.SetBool("isDying", true);
    }

    void Disappear()
    {
        PlayerStats.Points += 1;
        Destroy(gameObject);
    }
}
