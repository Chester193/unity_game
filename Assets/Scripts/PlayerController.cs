using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputControls playerInputControls;
    public Transform firePoint;
    public GameObject bulletObject;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    private void Awake()
    {
        playerInputControls = new PlayerInputControls(); 
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
        playerInputControls.Default.Fire.performed += _ => Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = playerInputControls.Default.MoveHorizontal.ReadValue<float>();
        vertical = playerInputControls.Default.MoveVertical.ReadValue<float>();
    }

    void Shoot() 
    {
        GameObject bullet = Instantiate(bulletObject, firePoint.position, firePoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(firePoint.up * 20f, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
        Rotate();
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
}
