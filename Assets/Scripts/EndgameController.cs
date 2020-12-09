using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndgameController : MonoBehaviour
{
    public Button menuButton;

    // Start is called before the first frame update
    void Start()
    {
        menuButton.GetComponent<Button>().onClick.AddListener(Menu);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerStats.Points = 0;
    }
}
