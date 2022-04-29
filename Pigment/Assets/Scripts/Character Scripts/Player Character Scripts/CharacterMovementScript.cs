using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    //references the input script
    private InputAssignmentScript _input;

    public Animator anim;

    //movespeed of the rig
    [SerializeField]
    private float moveSpeed;

    //turn speed of the rig
    [SerializeField]
    private float rotateSpeed;

    //bool that can make the rig face the ray hitpoint
    [SerializeField]
    private bool rotateTowardsMouse;

    //the calculated vector of the x and y inputs, aligned to the direction of the camera 
    private Vector3 targetVector = Vector3.zero;

    private Vector3 movementVector;

    private Vector3 mouseTarget;

    
    private void Awake()
    {
        _input = GetComponent<InputAssignmentScript>(); //this grabs the input script before anything else happens
    }

    private void FixedUpdate()
    {
        targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y); //keeps the targetVector updated
        movementVector = MoveTowardTarget(targetVector); //sets the movementVector by feeding the targetVector into the MoveTowardTarget function.

        if (_input.InputVector.x != 0 || _input.InputVector.y != 0)
        {
            anim.SetTrigger("Moving");
        }

        else
        {
            anim.ResetTrigger("Moving");
        }

        if (rotateTowardsMouse)
        {
            RotateTowardsMouseVector(); //This sets the rotation towards the mouse hit point. 
        }

        else
        {
            RotateTowardsMovementVector(movementVector); //This runs the RotateTowardsMovementVector with the movementVector fed in if rotateTowardsMouse is false
        }
    }

    private void RotateTowardsMouseVector()
    {
        Ray ray = Camera.main.ScreenPointToRay(_input.MousePosition); //send a ray from the camera to the pixel location of the mouse

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f)) //if it hits, it will return the hitInfo
        {
            mouseTarget = hitInfo.point; //the point where the ray hit in the scene
            mouseTarget.y = transform.position.y;

            transform.LookAt(mouseTarget); //causes the transform to look towards the mouse hitpoint
        }
    }

    private void RotateTowardsMovementVector(Vector3 movementVector)
    {
        if(movementVector.magnitude == 0) //ceases the rotation if the magnitude of the movementVector is 0
        {
            return;
        }

        Quaternion _rotation = Quaternion.LookRotation(movementVector); //uses Quaternion rotation to look at the movementVector that is calculated in the update loop
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotation, rotateSpeed); //causes the rotation "animation"
                                                                                                   //without this the model would snap from one degree to the next
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        float _speed = moveSpeed * Time.deltaTime; //internal variable speed is calculated from the set movespeed and the time since the last frame.

        targetVector = Quaternion.Euler(0, Camera.main.gameObject.transform.eulerAngles.y, 0) * targetVector; //sets the vectors to work regardless of the camera position
                                                                                                              //otherwise up, down, left, right become weird angles

        Vector3 _targetPosition = transform.position + targetVector * _speed; //internal variable of the position of the object and the original target vector, multiplied by the speed
        transform.position = _targetPosition; //sets the object position to the modified position

        return targetVector; //returns the targetVector that has been modified
    }
}
