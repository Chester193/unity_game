using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    float randX, randY;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Launch()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        randX = Random.Range(-100f, 100f);
        randY = Random.Range(-100f, 100f);
        rigidbody2d.AddForce(new Vector2(randX, randY));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
