using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndgameStats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text txt = GetComponent<Text>();
        txt.text = PlayerStats.Points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
