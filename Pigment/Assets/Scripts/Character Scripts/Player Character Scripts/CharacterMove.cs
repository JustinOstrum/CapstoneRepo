using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{   
    [Header("Movement")]
    public float moveSpeed;
    public float movementMultiplier = 10f;
    
    float rbGroundDrag = 8f;
    public float horizontalMovement;
    public float verticalMovement;
    
    Vector3 moveDirection;
    
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        PlayerMovementInput();

        ControlDrag();        
    }

    void PlayerMovementInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    void ControlDrag()
    {
        rb.drag = rbGroundDrag;    
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);        
    }
}
