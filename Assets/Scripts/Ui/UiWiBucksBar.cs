using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiWiBucksBar : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = PlayerStats.WiBucks.ToString();
    }
}
