using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void Skip()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        PlayerPrefs.SetInt("textHelp", 1);
        SceneManager.LoadScene("Menu");
    }

    public void Play()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Levels");
    }

    public void Help()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        PlayerPrefs.SetInt("textHelp", 1);
        SceneManager.LoadScene("Help");
    }

    public void Exit()
    {
        FindObjectOfType<AudioManager>().Play("Click");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void Next()
    {
        FindObjectOfType<AudioManager>().Play("Paper");
        int textHelp = PlayerPrefs.GetInt("textHelp");
        textHelp++;
        PlayerPrefs.SetInt("textHelp", textHelp);
        SceneManager.LoadScene("Help");
    }

    public void Previous()
    {
        FindObjectOfType<AudioManager>().Play("Paper");
        int textHelp = PlayerPrefs.GetInt("textHelp");
        textHelp--;
        PlayerPrefs.SetInt("textHelp", textHelp);
        SceneManager.LoadScene("Help");
    }
}
