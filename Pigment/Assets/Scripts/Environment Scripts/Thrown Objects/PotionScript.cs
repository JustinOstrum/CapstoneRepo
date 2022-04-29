using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ensures that the object has these components before runnign script
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class PotionScript : MonoBehaviour, IPooledObject
{
    public int potionValue;

    //variables for the object upwards and forwards forces when thrown
    public float upThrust = 3;
    public float forwardThrust = 3;

    //variable for the object triggering collision
    CarryScript carryScript;

    SlimeScript slimeScript;

    //rigidbody variable
    Rigidbody rb;

    //variable for the radius of the cauldron
    public float radius;

    //variables for determining if an object can be picked up, is being carried or has been thrown
    public bool isCarried;
    public bool canPickUp;
    bool isThrown;

    //variable for the object's transform
    Transform objectTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //grabs the rigidbody component
    }

    public virtual void Start()
    {
        isCarried = false; //ensures that objects are never carried at start
        canPickUp = false; //ensures that objects are never picked up at start, this only happens with trigger detection

        objectTransform = gameObject.transform; //condense the gameobject.transform for tidiness
    }

    void Update()
    {
        if (canPickUp && !isCarried && Input.GetButtonDown("Jump") && carryScript.isCarrying == false) //this allows the object to be picked up and carried at the location of the carry object.
                                                                                                       //it deactivates physics and parents the object to the carry object, giving it the same transform and position
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

        else if (isCarried && Input.GetButtonDown("Jump")) //this allows the object to be thrown, it reactivates physics on the object and unparents it
        {
            rb.isKinematic = false;
            objectTransform.parent = null;
            isCarried = false;

            ThrowCarriedObject(); //this call is in the update loop, but I need it to be fixedupdate
        }
    }

    public void ThrowCarriedObject() //this activates throwing the object that is being carried
    {
        isThrown = true; //sets is thrown to true
        carryScript.isCarrying = false;
    }

    public void OnObjectSpawn() //called by the object pooler when spawned
    {
        StartCoroutine(ThrowObjectOnSpawn());
    }

    public IEnumerator ThrowObjectOnSpawn() //throws the object when spawned at a random point around the circumference of the cauldron
    {
        gameObject.transform.forward = RandomPointOnCircleEdge(radius); // sets the random vector when spawned

        yield return new WaitForSeconds(.1f); //without the pause it wasn't able to get the random vector before throwing 

        isThrown = true;
    }

    private void FixedUpdate()
    {
        if (isThrown) //this was the best way I could find to turn an update loop call into a fixedupdate call
        {
            isThrown = false; //sets isthrown to false
            StartCoroutine(ThrowObject()); //the coroutien is run in the fixedUpdate
        }
    }

    private IEnumerator ThrowObject() //this coroutine disables gravity for the portion of the movement to allow for a more lofty object arc
    {
        rb.velocity = Vector3.zero;
        rb.useGravity = false;

        rb.AddRelativeForce(Vector3.forward.x,
                            Vector3.up.y * upThrust,
                            Vector3.forward.z * forwardThrust,
                            ForceMode.Impulse);

        yield return new WaitForSeconds(.5f);

        rb.useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {

        slimeScript = other.gameObject.GetComponent<SlimeScript>();
        
        if (other.CompareTag("Carry"))
        {
            carryScript = other.gameObject.GetComponent<CarryScript>(); //sets the overlapping carry object to the carryScript variable
            canPickUp = true;
        }

        if (slimeScript && !isCarried) //deactivates object when hitting a slime
        {            
            rb.useGravity = true;
            canPickUp = false;

            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other) //if the triggers are not overlapping, it cannot be picked up
    {
        if (other.CompareTag("Carry"))
        {
            canPickUp = false;
        }
    }

    private Vector3 RandomPointOnCircleEdge(float radius) //this takes the random X and Y of a flat circle, returns them as a vector3
    {
        var vector2 = Random.insideUnitCircle.normalized * radius;
        return new Vector3(vector2.x, 1, vector2.y);
    }
}
