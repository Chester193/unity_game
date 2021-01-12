using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectWorldController : MonoBehaviour
{
    public Text world2LockText;

    void Awake()
    {
        PlayerStats.ReadPlayerPrefs();
        world2LockText.gameObject.SetActive(true);
        if (PlayerStats.HasSecondLevelUnlocked == 1)
        {
            world2LockText.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.ReadPlayerPrefs();

        world2LockText.gameObject.SetActive(true);
        if (PlayerStats.HasSecondLevelUnlocked == 1) 
        {
            world2LockText.gameObject.SetActive(false);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(string level)
    {
        if (PlayerStats.Energy > 0)
        {
            PlayerStats.UpdateEnergy(-1);
            SceneManager.LoadScene(level);
        }
    }

    public void StartGameLevel2(string level)
    {
        if (PlayerStats.Energy > 0 && PlayerStats.HasSecondLevelUnlocked == 1)
        {
            PlayerStats.UpdateEnergy(-1);
            SceneManager.LoadScene(level);
        }
    }

    public void ChangeLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
