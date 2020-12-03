using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenager : MonoBehaviour
{
    internal int level { get; private set; }
    internal int experience { get; private set; }
    internal int experienceToNextLevel { get; private set; }

    private PlayerController player;

    public LevelMenager() 
    {
        level = 0;
        experience = 0;
        experienceToNextLevel = 100;
    }

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    public void AddExperience(int amount) 
    {
        experience += amount;

        if (experience >= experienceToNextLevel)
        {
            experience -= experienceToNextLevel;
            experienceToNextLevel = (int) ((float)experienceToNextLevel * 2f * 0.72);
            level++;

            player.LevelUp(200);
        }
    }
}
