using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public GameObject hero;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            hero.GetComponent<PlayerCombat>().Hurt();
            hero.GetComponent<PlayerCombat>().die();
        }
    }
}
