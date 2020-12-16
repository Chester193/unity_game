using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIExpBar : MonoBehaviour
{
    public Text level;
    public Image mask;
    float originalSize;

    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * PlayerStats.Exp());
        level.text = PlayerStats.Level.ToString();
    }
}
