using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourMenuScript : MonoBehaviour
{
    public List<Color> colors = new List<Color>();

    Material mat;

    int colourInt;

    Color currentColor;

    float colorTimer = 3f;
    float colorCounter;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;

        colors.Add(new Color32(255, 0, 0, 170)); //red
        colors.Add(new Color32(0, 0, 255, 170)); //blue
        colors.Add(new Color32(255, 255, 0, 170)); //yellow
        colors.Add(new Color32(0, 255, 0, 170)); //green
        colors.Add(new Color32(255, 128, 0, 170)); //orange
        colors.Add(new Color32(128, 0, 255, 170)); //purple       
    }

    private void Update()
    {
        colorCounter += Time.deltaTime;

        mat.color = currentColor;
        currentColor = Color.Lerp(currentColor, colors[colourInt], Mathf.PingPong(Time.deltaTime, .5f));

        if(colorCounter >= colorTimer)
        {
            colorCounter = 0;

            if(colourInt == colors.Count - 1)
            {
                colourInt = 0;
            }

            else
            {
                colourInt++;
            }
        }
    }
}
