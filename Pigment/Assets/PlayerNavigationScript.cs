using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavigationScript : MonoBehaviour
{
    public NavMeshAgent playerNavMeshAgent;

    public ParticleSystem footsteps;

    public GameManager gm;

    //A Camera that follow player movement
    public Camera playerCamera;
    
    //check player is running(moving) or not
    public bool isRunning;

    public LayerMask mask;

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

            if (playerNavMeshAgent.remainingDistance <= playerNavMeshAgent.stoppingDistance)
            {
                //The remaining distance are less or equal than the stopping distance it means character stop moving and reached destination
                isRunning = false;
            }

            else
            {
                //If remaining distance are greater than the stopping distance than character still moving toward Destination
                isRunning = true;
            }
        }
    }
}
