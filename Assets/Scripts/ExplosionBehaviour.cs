using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject, 0.4f);
        if (other.gameObject.name == "Rogue_06" || other.gameObject.name == "Rogue_06(Clone)")
        {
            other.gameObject.GetComponent<EnemyBehavior>().Die();
        } 
        else if (other.gameObject.name == "player")
        {
            PlayerController controller = other.gameObject.GetComponent<PlayerController>();

            if (controller != null)
            {
                controller.ChangeHealth(-1);
            }
        }
    }
}
