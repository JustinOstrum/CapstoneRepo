using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitSpawnWithUI : MonoBehaviour
{
    ObjectPoolingScript objectPooler;

    public List<Transform> spawnPoints = new List<Transform>();

    private void Start()
    {
        objectPooler = ObjectPoolingScript.Instance;
    }

    public void SpawnYellowFruit()
    {
        objectPooler.SpawnFromPool("SourFruitMoving", spawnPoints[0].position, Quaternion.identity);
    }

    public void SpawnRedFruit()
    {
        objectPooler.SpawnFromPool("SpicyFruitMoving", spawnPoints[1].position, Quaternion.identity);
    }

    public void SpawnBlueFruit()
    {
        objectPooler.SpawnFromPool("SweetFruitMoving", spawnPoints[2].position, Quaternion.identity);
    }
}
