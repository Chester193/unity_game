using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    private static int experienceToNextLevel = 10;
    private static int experienceAmount = 0;

    public static int Points { get; set; }
    public static int Level { get; private set; }

    public static float Exp()
    {
        return (float)experienceAmount / experienceToNextLevel;
    }

    public static void SavePoints()
    {
        experienceAmount += Points;
        UpdateLevel();
        Points = 0;
    }

    private static void UpdateLevel()
    {
        if (experienceAmount >= experienceToNextLevel)
        {
            experienceAmount -= experienceToNextLevel;
            experienceToNextLevel = (int)((float)experienceToNextLevel * 2f * 0.72);
            Level++;
        }
    }
}
