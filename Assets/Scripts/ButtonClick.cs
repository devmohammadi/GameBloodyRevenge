using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void Skip()
    {
        PlayerPrefs.SetInt("textHelp", 1);
        SceneManager.LoadScene("Menu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Levels");
    }

    public void Help()
    {
        PlayerPrefs.SetInt("textHelp", 1);
        SceneManager.LoadScene("Help");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }

    public void Next()
    {
        int textHelp = PlayerPrefs.GetInt("textHelp");
        textHelp++;
        PlayerPrefs.SetInt("textHelp", textHelp);
        SceneManager.LoadScene("Help");
    }

    public void Previous()
    {
        int textHelp = PlayerPrefs.GetInt("textHelp");
        textHelp--;
        PlayerPrefs.SetInt("textHelp", textHelp);
        SceneManager.LoadScene("Help");
    }
}
