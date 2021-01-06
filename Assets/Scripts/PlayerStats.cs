using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    private static int experienceToNextLevel = 10;
    private static int experienceAmount = 0;
    private static int maxEnergy = 5;

    public static int Energy { get; private set; } = maxEnergy;
    public static int Points { get; set; }
    public static int Level { get; private set; }
    public static int Money { get; private set; }
    public static int WiBucks { get; private set; } = 10;

    public static float GetExp()
    {
        return (float)experienceAmount / experienceToNextLevel;
    }

    public static float GetEnergy()
    {
        return (float)Energy / maxEnergy;
    }

    public static void UpdateEnergy(int value)
    {
        Energy += value;

        if (Energy < 0)
            Energy = 0;
        else if (Energy > maxEnergy)
            Energy = maxEnergy;
    }

    public static void SavePoints()
    {
        experienceAmount += Points;
        Money += Points;
        UpdateLevel();
        Points = 0;
    }

    private static void UpdateLevel()
    {
        while (experienceAmount >= experienceToNextLevel)
        {
            experienceAmount -= experienceToNextLevel;
            experienceToNextLevel = (int)((float)experienceToNextLevel * 2f * 0.72);
            Level++;
        }
    }

    public static void EarnMoney(int amount)
    {
        Money += amount;
    }

    public static bool SpendMoney(int amount)
    {
        if (Money - amount >= 0)
        {
            Money -= amount;
            return true;
        }

        return false;
    }

    public static void EarnWiBucks(int amount)
    {
        WiBucks += amount;
    }

    public static bool SpendWiBucks(int amount)
    {
        if (WiBucks >= amount)
        {
            WiBucks -= amount;
            return true;
        }

        return false;
    }
}
