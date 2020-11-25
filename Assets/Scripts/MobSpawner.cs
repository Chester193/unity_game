using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{

    public GameObject enemy;
    public float spawnRate = 1f;
    float nextSpawn = 0f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            Launch();
        }
    }

    void Launch()
    {
        Vector2 whereToSpawn = new Vector2(transform.position.x, transform.position.y);
        GameObject gameobject = Instantiate(enemy, whereToSpawn, Quaternion.identity);
    }
}
