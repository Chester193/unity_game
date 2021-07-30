using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Button playButton;
    public Button shopButton;

    void Awake()
    {
        PlayerStats.ReadPlayerPrefs();
    }

    // Start is called before the first frame update
    void Start()
    {
        playButton.GetComponent<Button>().onClick.AddListener(Play);
        shopButton.GetComponent<Button>().onClick.AddListener(Shop);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shop()
    {
        SceneManager.LoadScene("ShopMenu");
    }

    void Play()
    {
        //PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("ChooseMap");
    }
}
