using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RampScript : MonoBehaviour
{
    public GameObject panel;

    public MenuNavigationScript playerNav;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNav = other.gameObject.GetComponent<MenuNavigationScript>();

            panel.SetActive(true);

            playerNav.StopPlayer();
        }
    }
}
