using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//See PotionScript for comments as they function identically

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class WaterBottleScript : MonoBehaviour, IPooledObject
{
    public float upThrust;
    public float forwardThrust;

    CarryScript carryScript;

    WaterSliderScript waterSliderScript;

    SlimeScript slimeScript;

    Rigidbody rb;

    public bool isCarried;

    bool canPickUp;

    bool isThrown;

    Transform objectTransform;    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();      
    }

    private void Start()
    {
        isCarried = false;
        canPickUp = false;

        objectTransform = gameObject.transform;
    }

    private void OnTriggerEnter(Collider other)
    {

        slimeScript = other.gameObject.GetComponent<SlimeScript>();
        
        if (other.CompareTag("Carry"))
        {
            carryScript = other.gameObject.GetComponent<CarryScript>();

            canPickUp = true;
        }

        if (other.CompareTag("Cauldron") && !isCarried)
        {        
            rb.useGravity = true;
            canPickUp = false;

            waterSliderScript = other.gameObject.GetComponentInChildren<WaterSliderScript>();

            waterSliderScript.ResetWater(); //resets the water level of the water slider

            gameObject.SetActive(false);
        }

        if (other.CompareTag("Plant") && !isCarried)
        {
            rb.useGravity = true;
            canPickUp = false;

            gameObject.SetActive(false);
        }

        if (slimeScript && !isCarried) //deactivates object when hitting a slime
        {
            rb.useGravity = true;
            canPickUp = false;

            gameObject.SetActive(false);
        }
    }

    public void OnObjectSpawn()
    {
        rb.velocity = Vector3.zero;        
    }

    void Update()
    {
        if (canPickUp && !isCarried && Input.GetButtonDown("Jump") && carryScript.isCarrying == false)
        {
            if (carryScript != null)
            {                
                objectTransform.forward = carryScript.transform.forward;
                rb.isKinematic = true;
                objectTransform.position = carryScript.transform.position;
                objectTransform.parent = carryScript.transform;

                isCarried = true;
                carryScript.isCarrying = true;
            }
        }

        else if (isCarried && Input.GetButtonDown("Jump"))
        {
            rb.isKinematic = false;
            objectTransform.parent = null;

            isCarried = false;
            
            ThrowObjectUpdate();
        }
    }

    public void ThrowObjectUpdate()
    {
        isThrown = true;
        
        if (carryScript != null)
        {
            carryScript.isCarrying = false;
        }
    }

    private void FixedUpdate()
    {
        if (isThrown)
        {
            isThrown = false;
            StartCoroutine(ThrowObject());
        }
    }

    private IEnumerator ThrowObject()
    {        
        rb.useGravity = false;

        rb.AddRelativeForce(Vector3.forward.x,
                            Vector3.up.y * upThrust,
                            Vector3.forward.z * forwardThrust,
                            ForceMode.Impulse);

        yield return new WaitForSeconds(.2f);

        rb.useGravity = true;
    }    

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Carry"))
        {            
            canPickUp = false;
        }
    }
}
