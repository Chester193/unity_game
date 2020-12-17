using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public void ButtonSceneMove(string level)
    {
        SceneManager.LoadScene(level);
    }
}