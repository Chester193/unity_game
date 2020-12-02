using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "enemy" || other.gameObject.name == "enemy(Clone)") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        } else if (other.gameObject.name == "Tilemap") {
            Destroy(gameObject);
        }
    }
}
