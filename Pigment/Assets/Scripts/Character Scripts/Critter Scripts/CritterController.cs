using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CritterController : MonoBehaviour
{
    NavMeshAgent navAgent;
    
    public Animator anim;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }
}
