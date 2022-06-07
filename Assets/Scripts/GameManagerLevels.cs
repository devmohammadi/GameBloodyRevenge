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

    public void Level1()
    {
        if (Levels == 1)
        {
            SceneManager.LoadScene("Level1");
        }
        else
        {
            permissionAccess.SetActive(true);
            Invoke("closepermissionAccess", 1);
        }
    }

    public void Level2()
    {
        if (Levels == 2)
        {
            SceneManager.LoadScene("Level2");
        }
        else
        {
            permissionAccess.SetActive(true);
            Invoke("closepermissionAccess", 1);
        }
    }

    public void Level3()
    {
        if (Levels == 3)
        {
            SceneManager.LoadScene("Level3");
        }
        else
        {
            permissionAccess.SetActive(true);
            Invoke("closepermissionAccess", 1);
        }
    }

    public void Level4()
    {
        if (Levels == 4)
        {
            SceneManager.LoadScene("Level4");
        }
        else
        {
            permissionAccess.SetActive(true);
            Invoke("closepermissionAccess", 1);
        }
    }
}
