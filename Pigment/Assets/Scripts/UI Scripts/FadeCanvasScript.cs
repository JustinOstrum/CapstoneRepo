using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvasScript : MonoBehaviour
{
    public GameObject waterSlider;

    public GameObject fireSlider;

    public void Fade()
    {
        waterSlider.SetActive(true);
        fireSlider.SetActive(true);

        var canvGroup = GetComponent<CanvasGroup>();

        canvGroup.gameObject.SetActive(false);
    }
}
