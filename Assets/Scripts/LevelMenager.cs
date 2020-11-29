using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenager : MonoBehaviour
{
    private int level;
    private int experience;
    private int experienceToNextLevel;

    public LevelMenager() 
    {
        level = 0;
        experience = 0;
        experienceToNextLevel = 100;
    }

    public void AddExperience(int amount) 
    {
        experience += amount;

        if (experience >= experienceToNextLevel)
        {
            experience -= experienceToNextLevel;
            experienceToNextLevel = 0;
            level++;
        }
    }
}
