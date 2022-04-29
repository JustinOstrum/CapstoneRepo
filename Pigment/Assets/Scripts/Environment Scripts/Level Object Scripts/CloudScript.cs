using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    Transform thisTransform;

    float wait;

    float moveSpeed;

    void Start()
    {
        thisTransform = GetComponent<Transform>();

        StartCoroutine(CloudShimmy());
    }

    private void Update()
    {
        thisTransform.Translate(Vector3.right * moveSpeed * Time.deltaTime);        
    }

    public IEnumerator CloudShimmy()
    {
        moveSpeed = .5f;

        wait = Random.Range(3, 5);

        yield return new WaitForSeconds(wait);

        moveSpeed = -.5f;

        yield return new WaitForSeconds(wait);

        yield return CloudShimmy();
    }
}
