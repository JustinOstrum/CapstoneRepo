using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public CircleWipeController circleWipe;

    AudioManager audioManager;

    private int nextSceneToLoad;

    private int thisScene;

    public bool paused;

    private int themeInt;

    private void Start()
    {
        audioManager = AudioManager.instance;

        thisScene = SceneManager.GetActiveScene().buildIndex;

        if (thisScene == 4)
        {
            nextSceneToLoad = 1;
        }

        if (thisScene != 4)
        {
            nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        }

        if (thisScene == 0 || thisScene == 4)
        {
            audioManager.Play("MainTheme");
        }

        if (thisScene == 1)
        {
            audioManager.Play("SceneOneTheme");
        }

        if (thisScene == 2)
        {
            audioManager.Play("SceneTwoTheme");
        }

        if (thisScene == 3)
        {
            audioManager.Play("SceneThreeTheme");
        }

        circleWipe.FadeIn();

        StartCoroutine(WaitForFade());
    }

    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(3f);

        PauseGame();
    }

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                ResumeGame();
            }

            else if (!paused)
            {
                PauseGame();
            }
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(TransitionScene());
    }

    public IEnumerator TransitionScene()
    {
        if (thisScene == 0)
        {
            themeInt = 0;
        }

        if (thisScene == 1)
        {
            themeInt = 3;
        }

        if (thisScene == 2)
        {
            themeInt = 11;
        }

        if(thisScene == 3)
        {
            themeInt = 13;
        }

        var startVolume = audioManager.sounds[themeInt].source.volume;
        
        circleWipe.FadeOut();

        while (audioManager.sounds[themeInt].source.volume > 0)
        {
            audioManager.sounds[themeInt].source.volume -= startVolume * Time.deltaTime / 2f;
            yield return null;
        }


        yield return new WaitForSeconds(1f);

        audioManager.sounds[themeInt].source.Stop();
        audioManager.sounds[themeInt].source.volume = 0;

        SceneManager.LoadScene(nextSceneToLoad);
    }

    public void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        paused = false;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
