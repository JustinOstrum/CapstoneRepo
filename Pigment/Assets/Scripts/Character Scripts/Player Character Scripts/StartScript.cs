using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StartScript : MonoBehaviour
{
    public GameManager gm;

    public MenuNavigationScript playerNav;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gm.LoadNextScene();

            playerNav.playerNavMeshAgent.ResetPath();

            playerNav.playerNavMeshAgent.destination = gameObject.transform.position;
        }
    }
}
