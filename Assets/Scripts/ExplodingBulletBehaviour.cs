using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBulletBehaviour : MonoBehaviour
{
    public Transform explosionPoint;
    public GameObject bulletObject;
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Rogue_06" || other.gameObject.name == "Rogue_06(Clone)")
        {
            other.gameObject.GetComponent<EnemyBehavior>().Die();
        }
        Destroy(gameObject);
        explode();
    }

    void explode()
    {
        GameObject bullet = Instantiate(bulletObject, explosionPoint.position, explosionPoint.rotation);
        GameObject bullet2 = Instantiate(bulletObject, explosionPoint.position, explosionPoint.rotation);
        GameObject bullet3 = Instantiate(bulletObject, explosionPoint.position, explosionPoint.rotation);
        GameObject bullet4 = Instantiate(bulletObject, explosionPoint.position, explosionPoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rbBullet2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rbBullet3 = bullet3.GetComponent<Rigidbody2D>();
        Rigidbody2D rbBullet4 = bullet4.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(explosionPoint.up * 10f, ForceMode2D.Impulse);
        rbBullet2.AddForce(-explosionPoint.up * 10f, ForceMode2D.Impulse);
        rbBullet3.AddForce(explosionPoint.right * 10f, ForceMode2D.Impulse);
        rbBullet4.AddForce(-explosionPoint.right * 10f, ForceMode2D.Impulse);
    }
}
