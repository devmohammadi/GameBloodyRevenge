using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerVideoPlayer : MonoBehaviour
{
    void Start()
    {
       Invoke( "Menu", 149);
    }

    public void Menu()
    {
        PlayerPrefs.SetInt("textHelp", 1);
        SceneManager.LoadScene("Menu");
    }
}
