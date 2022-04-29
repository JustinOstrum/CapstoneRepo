using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CritterTrailer2Script : MonoBehaviour
{
    NavMeshAgent navAgent;

    public Animator anim;

    public Transform destinationPOS;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();

        StartCoroutine(LeaveScene());
    }

    IEnumerator LeaveScene()
    {
        yield return new WaitForSeconds(2f);

        anim.SetTrigger("Idle");

        yield return new WaitForSeconds(1f);

        anim.SetTrigger("Running");

        navAgent.destination = destinationPOS.position;
    }
}
