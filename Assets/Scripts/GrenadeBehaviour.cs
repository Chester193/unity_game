using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{

    public GameObject explosionEffect;
    Rigidbody2D rigidbody2d;
  void Start()
    {
        StartCoroutine(didExplode());
    }

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2.1f);
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator didExplode() 
    {
        yield return new WaitForSeconds(2);
        Instantiate(explosionEffect, transform.position, Quaternion.identity); 
    }

    
}
