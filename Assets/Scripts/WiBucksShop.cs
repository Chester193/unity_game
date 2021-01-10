using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WiBucksShop : MonoBehaviour
{
    public Text text;
    void Update()
    {
        text.text = PlayerStats.WiBucks.ToString();
    }

    public void BuyAnItem(string data)
    {
        string[] items = data.Split(',');
        int itemId;
        int cost;

        try
        {
            itemId = Int32.Parse(items[0]);
            cost = Int32.Parse(items[1]);
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        if (PlayerStats.SpendWiBucks(cost))
        {
            if(itemId == 1) //unlock map
            {
                //todo
            }
            if(itemId == 2)//unllock guns
            {
                PlayerStats.UnlockGuns();
            }
            if(itemId == 3) //+1 energy
            {
                PlayerStats.UpdateEnergy(1);
            }
            if(itemId == 4) //max energy
            {
                PlayerStats.UpdateEnergy(10);
            }
            if(itemId == 5)
            {
                PlayerStats.UnlockMines();
            }
            Debug.Log("Kupiono item o id " + itemId.ToString());
        }
        else
        {
            Debug.Log("Niewystarczajaco WiBucksow");
        }
    }
}
