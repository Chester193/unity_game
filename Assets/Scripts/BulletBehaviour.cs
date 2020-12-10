using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Rogue_06" || other.gameObject.name == "Rogue_06(Clone)") {
            other.gameObject.GetComponent<EnemyBehavior>().Die();
            Destroy(gameObject);
        } else if (other.gameObject.name == "Tilemap") {
            Destroy(gameObject);
        }
    }
}
