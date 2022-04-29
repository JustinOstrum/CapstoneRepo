using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    [SerializeField]
    private GameEvent fruitDropped;

    public GameObject targetFruit;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("RedFruit") || collision.gameObject.CompareTag("BlueFruit") || collision.gameObject.CompareTag("YellowFruit"))
        {
            targetFruit = collision.gameObject;
            fruitDropped.Invoke();
        }
    }
}
