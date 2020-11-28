using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient grandient;
    public Image fill;

    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;

        fill.color = grandient.Evaluate(1f);
    }

    public void SetHealth(int health) {
        slider.value = health;

        fill.color = grandient.Evaluate(slider.normalizedValue);
    }
}
