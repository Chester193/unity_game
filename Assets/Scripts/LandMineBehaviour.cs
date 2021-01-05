using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMineBehaviour : MonoBehaviour
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

    IEnumerator didExplode() 
    {
        yield return new WaitForSeconds(2);
        Instantiate(explosionEffect, transform.position, Quaternion.identity); 
    }
}
