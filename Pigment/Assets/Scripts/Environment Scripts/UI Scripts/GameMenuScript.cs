using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuScript : MonoBehaviour
{
    AudioManager audioManager;

    public GameObject quitPanel;
    public GameObject startPanel;
    public GameObject confirmation;
    
    public GameObject pather;
   

    private void Start()
    {
        audioManager = AudioManager.instance;

        StartCoroutine(EnableButton());
    }

    IEnumerator EnableButton()
    {
        yield return new WaitForSeconds(3f);

        confirmation.SetActive(true);        
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
        audioManager.Play("ClickPlay");
        startPanel.SetActive(false);
        pather.SetActive(true);
    }

    public void CloseWinMenu()
    {
        startPanel.SetActive(false);
    }

}
