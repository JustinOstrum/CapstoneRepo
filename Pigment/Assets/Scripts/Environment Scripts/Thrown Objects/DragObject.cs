using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour, IPooledObject
{
    AudioManager audioManager;

    private Vector3 screenPoint;
    private Vector3 offset;

    private string fruitTag;

    Vector3 spawnPoint;

    Rigidbody rb;

    public bool makeSound;

    private void Start()
    {
        fruitTag = gameObject.tag;

        audioManager = AudioManager.instance;

        makeSound = true;

        spawnPoint = gameObject.transform.position;        

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.y < -10f)
        {
            FruitDisappear();
        }
    }

    void OnMouseDown()
    {
        makeSound = true;

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    public void OnObjectSpawn()
    {
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        Debug.Log("Interface");
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.z = Mathf.Clamp(curPosition.z, -2.8f, -2.1f);
        curPosition.x = Mathf.Clamp(curPosition.x, -4.5f, 5.2f);
        curPosition.y = Mathf.Clamp(curPosition.y, 2.4f, 7f);
        transform.position = curPosition;       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cauldron"))
        {
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Critter"))
        {
            rb.isKinematic = true;
            
            StartCoroutine(FruitDisappear());
        }

        if (other.CompareTag("ResetPOS"))
        {
            rb.isKinematic = true;
            StartCoroutine(FruitDisappear());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Table"))
        {
            MakeSound();
        }
    }

    public void MakeSound()
    {
        if (makeSound)
        {
            makeSound = false;
            audioManager.Play("DropFruit");
        }
    }

    IEnumerator FruitDisappear()
    {
        yield return new WaitForSeconds(1.5f);

        makeSound = true;
        rb.isKinematic = false;
        gameObject.SetActive(false);
    }
}