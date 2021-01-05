using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiBucksController : ScriptableObject
{
    public int WiBucksAmount = 0;
    public static WiBucksController wiBucksController = WiBucksController.of();

    public static WiBucksController of() {
        return new WiBucksController();
    }

    private WiBucksController() { }
}
