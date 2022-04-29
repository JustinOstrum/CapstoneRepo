using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingFruitScript : MonoBehaviour
{
    AudioManager audioManager;

    Scene2GroundScript ground;

    CritterJumpScript critterScript;

    public Transform blueTarget;
    public Transform redTarget;
    public Transform yellowTarget;

    public ParticleSystem redConfetti;
    public ParticleSystem yellowConfetti;
    public ParticleSystem blueConfetti;

    public Vector3 force;

    public float forceAmp;

    Vector3 direction;

    public Transform spawnPOS;

    private Vector3 screenPoint;
    private Vector3 offset;

    public LayerMask mask;

    Rigidbody rb;
    
    private void Start()
    {
        ground = FindObjectOfType<Scene2GroundScript>();

        critterScript = FindObjectOfType<CritterJumpScript>();

        audioManager = AudioManager.instance;
        rb = GetComponent<Rigidbody>();        
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.z = Mathf.Clamp(curPosition.z, -11, -3.8f);
        curPosition.y = Mathf.Clamp(curPosition.y, -.9f, 3f);

        if (gameObject.CompareTag("RedFruit"))
        {
            curPosition.x = Mathf.Clamp(curPosition.x, -3.5f, -2.15f);
        }

        if (gameObject.CompareTag("YellowFruit"))
        {
            curPosition.x = Mathf.Clamp(curPosition.x, -.5f, .25f);
        }

        if (gameObject.CompareTag("BlueFruit"))
        {
            curPosition.x = Mathf.Clamp(curPosition.x, 2.3f, 3.5f);
        }

        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        audioManager.Play("ThrowSound");

        if (gameObject.CompareTag("RedFruit"))
        {            
            rb.velocity = Vector3.zero;
            direction = (redTarget.transform.position - gameObject.transform.position);
            rb.AddForce(direction * forceAmp + force, ForceMode.Impulse);
        }

        if (gameObject.CompareTag("YellowFruit"))
        {            
            rb.velocity = Vector3.zero;
            direction = (yellowTarget.transform.position - gameObject.transform.position);
            rb.AddForce(direction * forceAmp + force, ForceMode.Impulse);
        }

        if (gameObject.CompareTag("BlueFruit"))
        {            
            rb.velocity = Vector3.zero;
            direction = (blueTarget.transform.position - gameObject.transform.position);
            rb.AddForce(direction * forceAmp + force, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Critter"))
        {
            StartCoroutine(FruitEaten());            
        }

        if (other.CompareTag("RedBasket") && gameObject.CompareTag("RedFruit"))
        {
            redConfetti.Play();
            gameObject.SetActive(false);
        }

        if (other.CompareTag("YellowBasket") && gameObject.CompareTag("YellowFruit"))
        {
            yellowConfetti.Play();
            gameObject.SetActive(false);
        }

        if (other.CompareTag("BlueBasket") && gameObject.CompareTag("BlueFruit"))
        {
            blueConfetti.Play();
            gameObject.SetActive(false);
        }

        if (other.CompareTag("ResetPOS"))
        {
            rb.isKinematic = true;
            transform.position = spawnPOS.position;
            rb.velocity = Vector3.zero;
            rb.isKinematic = false;
            ground.ClearFruitList(gameObject);
        }

        if (other.CompareTag("ResetBasket"))
        {
            ground.ClearFruitList(gameObject);
            
            if (gameObject == critterScript.targetFruit)
            {
                critterScript.ActivateGetNewTarget();
            }
        }
    }

    public IEnumerator FruitEaten()
    {
        yield return new WaitForSeconds(2f);
        
        transform.position = spawnPOS.position;               

        yield return new WaitForSeconds(.1f);
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.isKinematic = false;
    }
}
