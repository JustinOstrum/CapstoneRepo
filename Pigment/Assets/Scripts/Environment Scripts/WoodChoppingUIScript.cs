using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodChoppingUIScript : MonoBehaviour
{
    public Text thisText;

    public ReticleScript reticle;

    private void Start()
    {
        thisText = GetComponent<Text>();

        thisText.enabled = false;
    }

    private void Update()
    {
        if (reticle.interactions[1])
        {
            thisText.enabled = true;
        }

        else
        {
            thisText.enabled = false;
        }
    }
}
