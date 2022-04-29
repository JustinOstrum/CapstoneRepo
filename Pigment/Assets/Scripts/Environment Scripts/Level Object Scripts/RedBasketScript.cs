using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBasketScript : MonoBehaviour
{
    public MainCanvasScene2Script mainCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedFruit"))
        {
            mainCanvas.IncrementRed();
        }

        if (other.CompareTag("YellowFruit"))
        {
            mainCanvas.IncrementYellow();
        }

        if (other.CompareTag("BlueFruit"))
        {
            mainCanvas.IncrementBlue();
        }
    }
}
