using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterContainerScript : MonoBehaviour
{
    //references the object pooler
    ObjectPoolingScript objectPooler;

    CarryScript carryScript;

    //transofrm of spawn object
    public Transform spawnTransform;

    //variable for tiemr
    bool canSpawn = false;

    //variables for controlling how quick water can be spawned
    public bool timerUp = false;
    public float spawnTimer;
    public float spawnCounter;

    void Start()
    {
        objectPooler = ObjectPoolingScript.Instance;// grabs reference to the object pooler        
    }

    private void Update()
    {
        spawnCounter += Time.deltaTime;

        if(spawnCounter >= spawnTimer)
        {
            timerUp = true;
        }

        if (canSpawn && timerUp && Input.GetButtonDown("Jump")) //if the timer is up and the collider is triggered, spawns a bottle
        {
            spawnCounter = 0;

            timerUp = false;

            SpawnWaterBottle();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Carry"))
        {
            canSpawn = true;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Carry"))
        {
            canSpawn = false;
        }
    }

    private void SpawnWaterBottle() //spawns a water bottle
    {
        objectPooler.SpawnFromPool("WaterBottle", spawnTransform.position, Quaternion.identity);     
    }
}
