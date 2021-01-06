using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyWiBuckManager : MonoBehaviour
{
    public void BuyWiBucks(int amount) {
        PlayerStats.EarnWiBucks(amount);
    }
}
