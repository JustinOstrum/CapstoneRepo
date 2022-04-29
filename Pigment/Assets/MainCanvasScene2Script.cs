using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasScene2Script : MonoBehaviour
{
    AudioManager audioManager;

    public GameObject arrow;
    public GameObject button;

    public Slider redSlider;
    public Slider blueSlider;
    public Slider yellowSlider;

    public GameObject panel;

    public GameManager gm;

    private void Awake()
    {
        audioManager = AudioManager.instance;
    }

    private void Start()
    {
        StartCoroutine(ActivateButton());
    }

    IEnumerator ActivateButton()
    {
        yield return new WaitForSeconds(3f);

        button.SetActive(true);
    }

    public void CloseTutorial()
    {
        audioManager.Play("ClickPlay");

        blueSlider.gameObject.SetActive(true);
        redSlider.gameObject.SetActive(true);
        yellowSlider.gameObject.SetActive(true);

        gm.ResumeGame();
        panel.SetActive(false);
    }

    public void IncrementRed()
    {
        redSlider.value += 1;
        audioManager.Play("DropFruit");
    }

    public void IncrementBlue()
    {
        blueSlider.value += 1;
        audioManager.Play("DropFruit");
    }

    public void IncrementYellow()
    {
        yellowSlider.value += 1;
        audioManager.Play("DropFruit");
    }

    public void Update()
    {
        if (redSlider.value == 7 && blueSlider.value == 7 && yellowSlider.value == 7)
        {
            arrow.SetActive(true);            

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //RaycastHit is a variable to store collision information
            RaycastHit hit;

            //Layermask defines what collision layers are pertinant to this ray's
            // firing
            int mask = LayerMask.GetMask("ArrowUI");

            //Physics.Raycast figures out if there are any colliders that have the same
            // mask and are within the distance defined, if so, that data is returned
            // via the hit variable
            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    audioManager.Play("LevelComplete");
                    gm.LoadNextScene();
                }

                Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.green);
            }
        }
    }
}
