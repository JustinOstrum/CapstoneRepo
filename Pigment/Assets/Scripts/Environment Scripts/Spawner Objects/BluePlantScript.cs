using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlantScript : MonoBehaviour
{
    //references the object pooler
    ObjectPoolingScript objectPooler;

    //the transform of the spawn object
    public Transform blueFruitSpawn;

    WaterBottleScript bottleScript;

    private void Start()
    {
        objectPooler = ObjectPoolingScript.Instance; //grabs reference to the object pooler

        StartCoroutine(GrowFruit());
    }
        
    private IEnumerator GrowFruit() ////calls the object pooler to spawn a fruit from the pool
    {
        yield return new WaitForSeconds(.5f);

        objectPooler.SpawnFromPool("BlueFruit", blueFruitSpawn.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other) //grows another fruit when the plant is watered
    {
        bottleScript = other.gameObject.GetComponent<WaterBottleScript>();

        if (other.CompareTag("Water") && bottleScript.isCarried == false)
        {
            StartCoroutine(GrowFruit());
        }
    }
}
