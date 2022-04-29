using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBasketScript : MonoBehaviour
{
    public MainCanvasScene2Script mainCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("YellowFruit"))
        {
            mainCanvas.IncrementYellow();
        }
    }
}