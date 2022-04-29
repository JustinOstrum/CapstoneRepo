using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour, IPooledObject
{
    public List<GameObject> logPieces = new List<GameObject>();

    List<Transform> logTransforms = new List<Transform>();

    Vector3 alignmentPos;

    public float movementTime;
    public float timeToMove;

    bool collectingPieces = false;
    
    private void Start()
    {
        alignmentPos = new Vector3(22.53f, 1.22f, -5.38f);

        foreach (GameObject _log in logPieces)
        {
            _log.GetComponent<Rigidbody>().isKinematic = true;
            logTransforms.Add(_log.transform);
        }        
    }

    private void Update()
    {
        if (collectingPieces)
        {
            CollectPieces();
        }
    }

    private void CollectPieces()
    {
        foreach (GameObject _log in logPieces)
        {
            _log.GetComponent<Rigidbody>().isKinematic = true;
            _log.transform.position = Vector3.MoveTowards(_log.transform.position, transform.position, 3f);
        }
    }

    public void OnObjectSpawn()
    {
        movementTime = 0;

        StartCoroutine(AlignLog());
    }

    public IEnumerator AlignLog()
    {
        while(movementTime < timeToMove)
        {
            transform.position = Vector3.Lerp(transform.position, alignmentPos, (movementTime / 30f));
            movementTime += Time.deltaTime;

            yield return null;
        }

        transform.position = alignmentPos;        

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {           
        if (other.CompareTag("Axe"))
        {
            foreach (GameObject _log in logPieces)
            {
                _log.GetComponent<Rigidbody>().isKinematic = false;                
            }

            StartCoroutine(CollectFirewood());
        }
    }

    public IEnumerator CollectFirewood()
    {
        yield return new WaitForSeconds(1f);

        collectingPieces = true;
    }
}
