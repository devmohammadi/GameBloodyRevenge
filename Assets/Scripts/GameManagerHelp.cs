using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerHelp : MonoBehaviour
{
    [SerializeField]
    private GameObject

            ButtonNext,
            ButtonPrevious,
            TextHelp1,
            TextHelp2,
            TextHelp3,
            TextHelp4;

    public int textHelp;

    void Start()
    {
        textHelp =
            PlayerPrefs.GetInt("textHelp");
    }

    void Update()
    {
        if (textHelp != 1)
        {
            ButtonPrevious.SetActive(true);
        }
        if (textHelp == 1)
        {
            ButtonPrevious.SetActive(false);
        }
        if (textHelp == 4)
        {
            ButtonNext.SetActive(false);
        }
        if (textHelp != 4)
        {
            ButtonNext.SetActive(true);
        }

        if (textHelp == 1)
        {
            TextHelp1.SetActive(true);
        }
        else
        {
            TextHelp1.SetActive(false);
        }

        if (textHelp == 2)
        {
            TextHelp2.SetActive(true);
        }
        else
        {
            TextHelp2.SetActive(false);
        }

        if (textHelp == 3)
        {
            TextHelp3.SetActive(true);

        }
        else
        {
            TextHelp3.SetActive(false);
        }

        if (textHelp == 4)
        {
            TextHelp4.SetActive(true);
        }
        else
        {
            TextHelp4.SetActive(false);
        }
    }
}
