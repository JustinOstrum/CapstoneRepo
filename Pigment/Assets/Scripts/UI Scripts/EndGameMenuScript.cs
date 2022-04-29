using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMenuScript : MonoBehaviour
{
    public GameObject quitPanel;
    public GameObject startPanel;
    public GameObject confirmation;
    public GameObject creditsButton;
    public GameObject pather;
    public GameObject credits;

    private void Start()
    {
        StartCoroutine(EnableButton());
    }

    IEnumerator EnableButton()
    {
        yield return new WaitForSeconds(3f);

        confirmation.SetActive(true);
        creditsButton.SetActive(true);
    }

    public void OpenWinMenu()
    {
        startPanel.SetActive(true);
    }

    public void CloseQuitPanel()
    {
        quitPanel.SetActive(false);
    }

    public void CloseStartPanel()
    {
        startPanel.SetActive(false);
        pather.SetActive(true);
    }

    public void CloseWinMenu()
    {
        startPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }
}
