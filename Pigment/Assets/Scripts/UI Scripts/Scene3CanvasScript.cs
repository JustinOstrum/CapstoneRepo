using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class Scene3CanvasScript : MonoBehaviour
{
    AudioManager audioManager;

    public GameObject panel;

    public GameManager gm;

    public GameObject button;

    private void Start()
    {
        audioManager = AudioManager.instance;

        StartCoroutine(ActivateButton());
    }

    IEnumerator ActivateButton()
    {
        yield return new WaitForSeconds(3f);

        button.SetActive(true);
    }


    public void CloseTutorial()
    {
        panel.SetActive(false);

        audioManager.Play("ClickPlay");

        gm.ResumeGame();
    }
}
