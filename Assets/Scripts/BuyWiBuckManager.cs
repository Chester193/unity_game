using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyWiBuckManager : MonoBehaviour
{
    private IAPManager iAPManager;

    // Start is called before the first frame update
    void Start()
    {
        iAPManager = IAPManager.Instance;
    }

    public void BuyWiBucks(int amount) {
        iAPManager.AddWiBucks(amount);
    }
}
