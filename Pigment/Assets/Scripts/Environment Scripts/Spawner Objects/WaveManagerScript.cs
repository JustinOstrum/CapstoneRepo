using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerScript : MonoBehaviour
{
    //#region Singleton

    //public static WaveManagerScript Instance;

    //#endregion

    //[System.Serializable]
    //public class Wave
    //{
    //    public string waveName;
    //    public int count;
    //    public float rate;
    //}

    //public enum SpawnState { SPAWNING, WAITING, COUNTING, FINISHED }

    //public SpawnState state = SpawnState.COUNTING;

    //ObjectPoolingScript objectPooler;

    //GameManager gameManager;

    //public List<Wave> waves;
    
    //private int nextWave = 0;

    //public Transform customerSpawn;

    //public float timeBetweenWaves;
    //public float waveCountdown;

    //public int waveNumber;
    //public int customerCount;

    //private void Start()
    //{
    //    gameManager = GetComponent<GameManager>();
    //    Instance = this;
    //    objectPooler = ObjectPoolingScript.Instance;
    //    waveNumber = 1;
    //    customerCount = 0;
    //    waveCountdown = timeBetweenWaves;
    //}

    //private void Update()
    //{
    //    Debug.Log(state);        

    //    if (state == SpawnState.WAITING)
    //    {
    //        if (customerCount == 0)
    //        {
    //            WaveCompleted();
    //        }
    //        else
    //        {
    //            return;
    //        }
    //    }

    //    if (waveCountdown <= 0 && customerCount == 0 && state != SpawnState.FINISHED)
    //    {
    //        if (state != SpawnState.SPAWNING)
    //        {
    //            StartCoroutine(SpawnCustomerWave(waves[nextWave]));
    //        }
    //    }

    //    else
    //    {
    //        waveCountdown -= Time.deltaTime;
    //    }
    //}

    //void WaveCompleted()
    //{
    //    state = SpawnState.COUNTING;
    //    waveCountdown = timeBetweenWaves;

    //    if (nextWave + 1 > waves.Count - 1)
    //    {
    //        state = SpawnState.FINISHED;
    //    }
    //    else
    //    {
    //        nextWave++;
    //    }
    //}

    //public IEnumerator SpawnCustomerWave(Wave _wave)
    //{
    //    state = SpawnState.SPAWNING;

    //    for (int i = 0; i < _wave.count; i++)
    //    {
    //        SpawnCustomer();
    //        customerCount++;

    //        yield return new WaitForSeconds(_wave.rate);
    //    }

    //    state = SpawnState.WAITING;

    //    waveNumber++;

    //    if (waveNumber <= 3)
    //    {
    //        gameManager.gameStage = GameStage.EarlyGame;
    //    }

    //    else if (waveNumber >= 4 && waveNumber <= 6)
    //    {
    //        gameManager.gameStage = GameStage.MidGame;
    //    }

    //    else if (waveNumber >= 7 && waveNumber <= 9)
    //    {
    //        gameManager.gameStage = GameStage.LateGame;
    //    }

    //    yield break;
    //}

    //private void SpawnCustomer()
    //{
    //    objectPooler.SpawnFromPool("Slime", customerSpawn.position, Quaternion.Euler(-90, 0, 0));
    //}
}
