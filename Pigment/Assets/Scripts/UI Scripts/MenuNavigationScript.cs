using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MenuNavigationScript : MonoBehaviour
{
    public NavMeshAgent playerNavMeshAgent;

    public ParticleSystem footsteps;

    public GameManager gm;

    public Animator anim;

    public Transform resetPos;

    //A Camera that follow player movement
    public Camera playerCamera;

    //check player is running(moving) or not
    public bool isRunning;

    public LayerMask mask;

    public void StartSayHi()
    {
        playerNavMeshAgent.ResetPath();

        StartCoroutine(SayHi());
    }

    IEnumerator SayHi()
    {
        anim.SetBool("isWaving", true);

        yield return new WaitForSeconds(2f);

        anim.SetBool("isWaving", false);
    }

    private void Update()
    {
        if (!gm.paused)
        {
            //if the left button of is clicked
            if (Input.GetMouseButton(0))
            {
                //Unity cast a ray from the position of mouse cursor on-screen toward the 3D scene.
                Ray myRay = playerCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit myRaycastHit;

                if (Physics.Raycast(myRay, out myRaycastHit, 100f, mask))
                {
                    //Assign ray hit point as Destination of Navemesh Agent (Player)
                    playerNavMeshAgent.SetDestination(myRaycastHit.point);
                }
            }

            //Compare the value of the remaining distance and the stopping distance(Destination point)

            if (playerNavMeshAgent.remainingDistance <= playerNavMeshAgent.stoppingDistance)
            {
                anim.SetBool("isRunning", false);
            }

            else
            {
                anim.SetBool("isRunning", true);
            }

        }
    }

    public void ResetPos()
    {
        playerNavMeshAgent.destination = resetPos.position;
    }

    public void StartPlayer()
    {
        playerNavMeshAgent.ResetPath();
        playerNavMeshAgent.isStopped = false;
    }

    public void StopPlayer()
    {
        playerNavMeshAgent.ResetPath();
        playerNavMeshAgent.isStopped = true;
    }
}
