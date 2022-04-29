using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPileScript : MonoBehaviour
{
    public GameObject logSpawn;

    public AxeScript axeScript;

    ObjectPoolingScript objectPooler;

    public bool logCanSpawn = true;

    void Start()
    {
        objectPooler = ObjectPoolingScript.Instance;        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && logCanSpawn)
        {
            logCanSpawn = false;

            StartCoroutine(SpawnLog(logCanSpawn));
        }
    }

    public IEnumerator SpawnLog(bool canSpawnLog)
    {
        objectPooler.SpawnFromPool("Log", logSpawn.transform.position, logSpawn.transform.rotation);
        
        yield return new WaitForSeconds(1f);

        StartCoroutine(axeScript.SwingAxe(canSpawnLog));

        yield return new WaitForSeconds(2f);

        logCanSpawn = true;
    }
}
