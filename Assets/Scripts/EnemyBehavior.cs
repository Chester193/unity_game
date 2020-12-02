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
        if(other.gameObject.name == "player")
        {
            Destroy(gameObject);
        }
    }
}
