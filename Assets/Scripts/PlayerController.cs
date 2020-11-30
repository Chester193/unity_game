using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;

    public ExpBar expBar;
    private LevelMenager levelMenager;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        levelMenager = GetComponent<LevelMenager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        expBar.SetExp(levelMenager.experience, levelMenager.experienceToNextLevel);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            levelMenager.AddExperience(74);
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    void TakeDamage(int damage) 
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void LevelUp(int newMaxHealth) 
    {
        healthBar.SetMaxHealthOnLevelUp(newMaxHealth);

        int newCurrentHealth = (int) (newMaxHealth * ((float)currentHealth / maxHealth));
        healthBar.SetHealth(newCurrentHealth);

        currentHealth = newCurrentHealth;
        maxHealth = newMaxHealth;
    }
}
