using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerLevels : MonoBehaviour
{
    [SerializeField]
    private GameObject

            key2,
            key3,
            key4;

    [SerializeField]
    private GameObject

            level1,
            level2,
            level3,
            level4;

    [SerializeField]
    private GameObject permissionAccess;

    public int Levels;

    void Start()
    {
        Levels =
            PlayerPrefs.HasKey("Levels") ? PlayerPrefs.GetInt("Levels") : 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Levels == 1)
        {
            level1.SetActive(true);
            key2.SetActive(true);
            key3.SetActive(true);
            key4.SetActive(true);
        }
        else if (Levels == 2)
        {
            level2.SetActive(true);
            key3.SetActive(true);
            key4.SetActive(true);
        }
        else if (Levels == 3)
        {
            level3.SetActive(true);
            key4.SetActive(true);
        }
        else if (Levels == 4)
        {
            level4.SetActive(true);
        }
    }

    void closepermissionAccess()
    {
        permissionAccess.SetActive(false);
    }

    void Permission()
    {
        FindObjectOfType<AudioManager>().Play("Permission");
        permissionAccess.SetActive(true);
        Invoke("closepermissionAccess", 1);
    }

    public void Level1()
    {
        if (Levels == 1)
        {
            FindObjectOfType<AudioManager>().Play("Click");
            SceneManager.LoadScene("Level1");
        }
        else
        {
            Permission();
        }
    }

    public void Level2()
    {
        if (Levels == 2)
        {
            FindObjectOfType<AudioManager>().Play("Click");
            SceneManager.LoadScene("Level2");
        }
        else
        {
            Permission();
        }
    }

    public void Level3()
    {
        if (Levels == 3)
        {
            FindObjectOfType<AudioManager>().Play("Click");
            SceneManager.LoadScene("Level3");
        }
        else
        {
            Permission();
        }
    }

    public void Level4()
    {
        if (Levels == 4)
        {
            FindObjectOfType<AudioManager>().Play("Click");
            SceneManager.LoadScene("Level4");
        }
        else
        {
            Permission();
        }
    }
}
