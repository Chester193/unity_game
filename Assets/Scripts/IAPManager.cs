using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPManager : MonoBehaviour
{
    private static IAPManager instance = null;
    public static IAPManager Instance { get { return instance; } }
    private int _coins = 111;
    public int coins { get { return _coins; } }


    private void Awake()
    {
        // if instance is not yet set, set it and make it persistent between scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // if instance is already set and this is not the same object, destroy it
            if (this != instance) { Destroy(gameObject); }
        }
    }

    public void AddWiBucks(int amount) 
    {
        _coins += amount;
    }

    public bool ChargeWiBuckets(int amount) 
    {
        if (_coins < amount) {
            return false;
        }

        _coins -= amount;
        return true;
    }

    public void BuyFaild() {
        Debug.Log("nie udalo sie kupic");
    }
}
