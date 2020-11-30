using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider slider;
    public Text displayExpNumbers;

    public void SetExp(int expPoints, int maxExp)
    {
        slider.maxValue = maxExp;
        slider.value = expPoints;
        SetCurrentExpText(expPoints, maxExp);
    }

    private void SetCurrentExpText(int currentExp, int maxExp) 
    {
        displayExpNumbers.text = string.Format("Exp: {0}/{1}", currentExp, maxExp);
    }
}
