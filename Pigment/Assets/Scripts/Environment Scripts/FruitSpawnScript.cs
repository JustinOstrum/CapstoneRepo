using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FruitSpawnScript : MonoBehaviour
{
    ObjectPoolingScript objectPooler;

    public MainCanvasScript canvasScript;

    public Transform yellowSpawn;
    public Transform redSpawn;
    public Transform blueSpawn;

    int fruitIndex;

    List<string> fruitNames = new List<string>();

    public List<GameObject> fruitsSpawned = new List<GameObject>();

    float yPos;
    float xPos;

    private void Start()
    {
        objectPooler = ObjectPoolingScript.Instance;

        for (int i = 0; i < 3; i++)
        {
            SpawnRedFruit();
            SpawnBlueFruit();
            SpawnYellowFruit();
        }
    }

    public void SpawnBlueFruit()
    {
        if (canvasScript.blueSlider.value < canvasScript.fruitsToCollect)
        {
            xPos = Random.Range(-9f, 4f);
            yPos = Random.Range(-1.60f, .1f);

            fruitsSpawned.Add(objectPooler.SpawnFromPool("BlueFruit", new Vector3(xPos, 0f, yPos), Quaternion.identity));
        }
    }

    public void SpawnRedFruit()
    {
        if (canvasScript.redSlider.value < canvasScript.fruitsToCollect)
        {
            xPos = Random.Range(-9f, 4f);
            yPos = Random.Range(.1f, 1.8f);

            fruitsSpawned.Add(objectPooler.SpawnFromPool("RedFruit", new Vector3(xPos, 0f, yPos), Quaternion.identity));
        }
    }

    public void SpawnYellowFruit()
    {
        if (canvasScript.yellowSlider.value < canvasScript.fruitsToCollect)
        {
            xPos = Random.Range(-9f, 4f);
            yPos = Random.Range(-3.3f, -1.60f);

            fruitsSpawned.Add(objectPooler.SpawnFromPool("YellowFruit", new Vector3(xPos, 0f, yPos), Quaternion.identity));
        }
    }

    public void SpawnYellowBasketFruit()
    {
        objectPooler.SpawnFromPool("YellowFruitBasket", yellowSpawn.position, Quaternion.identity);
    }

    public void SpawnBlueBasketFruit()
    {
        objectPooler.SpawnFromPool("BlueFruitBasket", blueSpawn.position, Quaternion.identity);
    }

    public void SpawnRedBasketFruit()
    {
        objectPooler.SpawnFromPool("RedFruitBasket", redSpawn.position, Quaternion.identity);
    }

    public void RemoveFruitFromList(GameObject fruit)
    {
        if (fruitsSpawned.Contains(fruit))
        {
            fruitsSpawned.Remove(fruit);
        }
    }
}