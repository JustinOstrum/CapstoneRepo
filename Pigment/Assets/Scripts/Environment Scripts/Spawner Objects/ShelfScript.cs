using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfScript : MonoBehaviour
{
    //references the object pooler
    ObjectPoolingScript objectPooler;

    public List<Transform> spawnPoints = new List<Transform>();

    public IngredientData iData;

    public int fruitToSpawn;

    protected virtual void Start()
    {
        objectPooler = ObjectPoolingScript.Instance; //grabs reference to the object pooler

        StartCoroutine(GrowFruit());
    }

    protected virtual IEnumerator GrowFruit() ////calls the object pooler to spawn a fruit from the pool
    {
        
        yield return new WaitForSeconds(.5f);

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            objectPooler.SpawnFromPool(iData.fruitNames[fruitToSpawn], spawnPoints[i].position, Quaternion.identity);
        }
    }    
}
