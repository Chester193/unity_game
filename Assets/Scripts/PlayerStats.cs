using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    private static int experienceToNextLevel = 10;
    private static int experienceAmount = 0;
    private static int maxEnergy = 5;
    private static TimeSpan energyUpdatePeriod = new TimeSpan(0, 1, 0);
    private static DateTime lastEnergyUpdate = DateTime.Now;

    public static int Energy { get; private set; } = maxEnergy;
    public static int Points { get; set; }
    public static int Level { get; private set; }
    public static int Money { get; private set; }
    public static int WiBucks { get; private set; }

    public static int HasAllGuns { get; private set; }
    public static int HasMines { get; private set; }


    public static float GetExp()
    {
        return (float)experienceAmount / experienceToNextLevel;
    }

    public static float GetEnergy()
    {
        RestoreEnergy();
        return (float)Energy / maxEnergy;
    }

    public static void RestoreEnergy()
    {
        while (DateTime.Now - energyUpdatePeriod > lastEnergyUpdate)
        {
            lastEnergyUpdate = lastEnergyUpdate + energyUpdatePeriod;

            if (Energy >= maxEnergy)
                break;

            UpdateEnergy(1);
        }
        SaveEnergy();
        SaveEnergyTimer();
    }

    public static void UpdateEnergy(int value)
    {
        Energy += value;

        if (Energy < 0)
            Energy = 0;
        else if (Energy > maxEnergy)
            Energy = maxEnergy;

        SaveEnergy();
    }

    public static void SavePoints()
    {
        experienceAmount += Points;
        EarnMoney(Points);
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
        SaveLevel();
    }

    public static void EarnMoney(int amount)
    {
        Money += amount;
        SaveMoney();
    }

    public static bool SpendMoney(int amount)
    {
        if (Money - amount >= 0)
        {
            Money -= amount;
            SaveMoney();
            return true;
        }

        SaveMoney();
        return false;
    }

    public static void EarnWiBucks(int amount)
    {
        WiBucks += amount;
        SaveWiBucks();
    }

    public static bool SpendWiBucks(int amount)
    {
        if (WiBucks >= amount)
        {
            WiBucks -= amount;
            SaveWiBucks();
            return true;
        }

        SaveWiBucks();
        return false;
    }

    private static void SaveMoney()
    {
        PlayerPrefs.SetInt("money", Money);
        PlayerPrefs.Save();
    }

    private static void SaveWiBucks()
    {
        PlayerPrefs.SetInt("wi_bucks", WiBucks);
        PlayerPrefs.Save();
    }

    private static void SaveEnergy()
    {
        PlayerPrefs.SetInt("energy", Energy);
        PlayerPrefs.Save();
    }

    private static void SaveEnergyTimer()
    {
        PlayerPrefs.SetString("last_energy_update", lastEnergyUpdate.ToString());
        PlayerPrefs.Save();
    }

    private static void SaveLevel()
    {
        PlayerPrefs.SetInt("level", Level);
        PlayerPrefs.SetInt("exp", experienceAmount);
        PlayerPrefs.SetInt("exp_to_next_level", experienceToNextLevel);
        PlayerPrefs.Save();
    }

    public static void UnlockGuns()
    {
        PlayerPrefs.SetInt("has_all_guns", 1);
        PlayerPrefs.Save();
    }

    public static void UnlockMines()
    {
        PlayerPrefs.SetInt("has_mines", 1);
        PlayerPrefs.Save();
    }

    public static void ReadPlayerPrefs()
    {
        Money = PlayerPrefs.GetInt("money", Money);
        WiBucks = PlayerPrefs.GetInt("wi_bucks", WiBucks);
        Energy = PlayerPrefs.GetInt("energy", Energy);
        Level = PlayerPrefs.GetInt("level", Level);
        experienceAmount = PlayerPrefs.GetInt("exp", experienceAmount);
        experienceToNextLevel = PlayerPrefs.GetInt("exp_to_next_level", experienceToNextLevel);

        HasAllGuns = PlayerPrefs.GetInt("has_all_guns", HasAllGuns);
        HasMines = PlayerPrefs.GetInt("has_mines", HasMines);

        string last_energy_update = PlayerPrefs.GetString("last_energy_update", "");
        if (last_energy_update != "")
            lastEnergyUpdate = DateTime.Parse(last_energy_update);
    }
}
