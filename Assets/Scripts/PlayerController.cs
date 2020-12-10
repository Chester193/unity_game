using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private PlayerInputControls playerInputControls;
    public GameObject bulletPrefab;
    public GameObject explodingBulletObject;

    Rigidbody2D rigidbody2d;
    Animator animator;
    Transform transform;
    float horizontal;
    float vertical;
    Vector2 lookDirection = new Vector2(1, 0);

    public int maxHealth = 5;
    public int Health { get; private set; }

    int currentWeapon = 0;
    int weaponAmount = 3;
    float nextFireTime = 0;
    float pistolCooldown = 0.2f;
    float shotgunCooldown = 1;
    float diagonalCooldown = 0.5f;
    float grenadeCooldown = 2;

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
        playerInputControls.Default.ChangeWeapon.performed += _ => ChangeWeapon();
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
        // Pistol
        if (currentWeapon == 0 && Time.time > nextFireTime)
        {
            GameObject bulletObject = Instantiate(bulletPrefab, rigidbody2d.position + Vector2.up * 0.2f, Quaternion.identity);
            BulletBehaviour bullet = bulletObject.GetComponent<BulletBehaviour>();
            bullet.Launch(lookDirection, 20f);
            nextFireTime = Time.time + pistolCooldown;
        }
        // Shotgun
        else if (currentWeapon == 1 && Time.time > nextFireTime)
        {
            Random random = new Random();
            for (int i = 0; i < Random.Range(5, 15); i++)
            {

                GameObject bulletObject = Instantiate(bulletPrefab, rigidbody2d.position + Vector2.up * 0.2f, Quaternion.identity);
                BulletBehaviour bullet = bulletObject.GetComponent<BulletBehaviour>();
                bullet.Launch(lookDirection * Random.Range(10f, 15f) + new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)), 1);
            }
            nextFireTime = Time.time + shotgunCooldown;
        }
        // Diagonal gun
        else if (currentWeapon == 2 && Time.time > nextFireTime)
        {
            GameObject bullet = Instantiate(bulletPrefab, rigidbody2d.position + Vector2.up * 0.2f, Quaternion.identity);
            GameObject bullet2 = Instantiate(bulletPrefab, rigidbody2d.position + Vector2.up * 0.2f, Quaternion.identity);
            GameObject bullet3 = Instantiate(bulletPrefab, rigidbody2d.position + Vector2.up * 0.2f, Quaternion.identity);
            BulletBehaviour frontBullet = bullet.GetComponent<BulletBehaviour>();
            BulletBehaviour leftBullet = bullet2.GetComponent<BulletBehaviour>();
            BulletBehaviour rightBullet = bullet3.GetComponent<BulletBehaviour>();
            frontBullet.Launch(lookDirection, 10f);
            rightBullet.Launch(GetDiagonals(lookDirection)[0], 10f);
            leftBullet.Launch(GetDiagonals(lookDirection)[1], 10f);
            nextFireTime = Time.time + diagonalCooldown;
        }
        // Grenade
        else if (currentWeapon == 3 && Time.time > nextFireTime)
        {
            GameObject bulletObject = Instantiate(explodingBulletObject, rigidbody2d.position + Vector2.up * 0.2f, Quaternion.identity);
            ExplodingBulletBehaviour bullet = bulletObject.GetComponent<ExplodingBulletBehaviour>();
            bullet.Launch(lookDirection, 10f);
            nextFireTime = Time.time + grenadeCooldown;
        }
    }

    Vector2 [] GetDiagonals(Vector2 front)
    {
        Vector2 right = new Vector2(front.x, front.y);
        Vector2 left = new Vector2(front.x, front.y);
        if (front.x == 0)
        {
            right.x = 1;
            left.x = -1;
        }
        else if (front.y == 0)
        {
            right.y = 1;
            left.y = -1;
        }
        else
        {
            right.x = 0;
            left.y = 0;
        }
        return new Vector2 [] {left, right};
    }

    void ChangeWeapon()
    {
        nextFireTime = 0;
        if (currentWeapon + 1 > weaponAmount)
        {
            currentWeapon = 0;
        }
        else
        {
            currentWeapon++;
        }
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
