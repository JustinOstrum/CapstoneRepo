using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFruitBarrierScript : MonoBehaviour
{
    public Scene2GroundScript groundScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedFruit") || other.CompareTag("YellowFruit") || other.CompareTag("BlueFruit"))
        {
            IdentifyFruit(other.gameObject);
        }
    }

    public void IdentifyFruit(GameObject fruit)
    {
        groundScript.fruits.Remove(fruit);
    }
}
