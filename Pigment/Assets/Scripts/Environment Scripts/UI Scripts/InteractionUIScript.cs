using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUIScript : MonoBehaviour
{
    public ReticleScript reticle;

    public Text thisText;

    private void Start()
    {
        thisText = GetComponent<Text>();

        thisText.text = "";
    }

    private void Update()
    {
        if (reticle.interactions[1])
        {
            thisText.text = "Chop wood?";
        }

        else
        {
            thisText.text = "";
        }
    }
}
