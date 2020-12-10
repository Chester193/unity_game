using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private PlayerInputControls playerInputControls;
    public GameObject bulletPrefab;

    Rigidbody2D rigidbody2d;
    Animator animator;
    Transform transform;
    float horizontal;
    float vertical;
    Vector2 lookDirection = new Vector2(1, 0);

    public int maxHealth = 5;
    public int Health { get; private set; }

    private void Awake()
    {
        playerInputControls = new PlayerInputControls();
        Health = maxHealth;
    }

    private void OnEnable()
    {
        playerInputControls.Enable();
    }

    private void OnDisable()
    {
        playerInputControls.Disable(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        playerInputControls.Default.Fire.performed += _ => Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = playerInputControls.Default.MoveHorizontal.ReadValue<float>();
        vertical = playerInputControls.Default.MoveVertical.ReadValue<float>();

        if (horizontal != 0 || vertical != 0)
        {
            lookDirection = new Vector2(horizontal, vertical);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (horizontal > 0)
            transform.localScale = new Vector3(0.15f, 0.15f, 1f);
        else if (horizontal < 0)
            transform.localScale = new Vector3(-0.15f, 0.15f, 1f);
    }

    void Shoot() 
    {
        GameObject bulletObject = Instantiate(bulletPrefab, rigidbody2d.position + Vector2.up * 0.2f, Quaternion.identity);
        BulletBehaviour bullet = bulletObject.GetComponent<BulletBehaviour>();
        bullet.Launch(lookDirection, 300);
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
        //Rotate();
    }

    void Rotate()
    {
         if (vertical == 1) {
            if (horizontal == 1) {
                rigidbody2d.rotation = 315f;
            } else if (horizontal == -1) {
                rigidbody2d.rotation = 45f;
            } else {
                rigidbody2d.rotation = 0;
            }
        } else if (vertical == -1) {
            if (horizontal == 1) {
                rigidbody2d.rotation = 235f;
            } else if (horizontal == -1) {
                rigidbody2d.rotation = 135f;
            } else {
                rigidbody2d.rotation = 180f;
            }
        } else {
            if (horizontal == 1) {
                rigidbody2d.rotation = 270f;
            } else if (horizontal == -1) {
                rigidbody2d.rotation = 90f;
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        Health += amount;

        if (Health > maxHealth)
            Health = maxHealth;
        else if (Health <= 0)
            animator.SetBool("isDying", true);

        UIHealthBar.instance.SetValue(Health / (float)maxHealth);
    }

    void Disappear()
    {
        SceneManager.LoadScene("Endgame");
    }
}
