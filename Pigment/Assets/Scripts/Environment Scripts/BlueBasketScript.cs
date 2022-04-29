using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBasketScript : MonoBehaviour
{
    public MainCanvasScene2Script mainCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlueFruit"))
        {
            mainCanvas.IncrementBlue();
        }
    }
}
