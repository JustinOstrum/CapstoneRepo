using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogsScript : MonoBehaviour
{
    //references the object pooler
    ObjectPoolingScript objectPooler;

    //the transform of the spawn object
    public Transform spawnTransform;

    //bool for checking if timer is up
    bool canSpawn = false;

    //variables for determining if wood can spawn
    public bool timerUp = false;
    public float spawnTimer;
    public float spawnCounter;
    public float timerReset;

    void Start()
    {
        objectPooler = ObjectPoolingScript.Instance; //grabs reference to the object pooler
        timerReset = 0; //makes sure the reset variable is always 0
    }

    private void Update()
    {
        spawnCounter += Time.deltaTime;

        if (spawnCounter >= spawnTimer)
        {
            timerUp = true;
        }

        if (canSpawn && timerUp && Input.GetButtonDown("Jump")) //if the timer is up and canspawn is true, the fuel will spawn
        {
            spawnCounter *= timerReset;
            timerUp = false;
            SpawnLog();
        }
    }

    private void OnTriggerEnter(Collider other) //checks to see if the carry object is triggering collision
    {
        if (other.CompareTag("Carry"))
        {
            canSpawn = true;
        }
    }

    private void OnTriggerExit(Collider other) //cannot pick up object if it is not in collision with carry object 
    {
        if (other.CompareTag("Carry"))
        {
            canSpawn = false;
        }
    }

    private void SpawnLog() //calls the object pooler to grab the next inactive log in the pool
    {
        objectPooler.SpawnFromPool("Log", spawnTransform.position, Quaternion.identity);
    }
}
