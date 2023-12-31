using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject transition;
    public GameObject pauseMenu;
    public GameObject askToContinue;
    public GameObject howToPlay;
    bool sawTutorial;
    bool meniuDeschis;
    public GameObject sunetGo;
    public GameObject sunetPWRGo;

    void Update()
    {
        if(howToPlay.activeSelf && SceneManager.GetActiveScene().name == "MainMenu") sawTutorial=true;
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "MainMenu" && !meniuDeschis)
        {
            Time.timeScale=0;
            pauseMenu.SetActive(true);
            meniuDeschis = true;
        }
        else if(meniuDeschis && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale=1;
            pauseMenu.SetActive(false);
            meniuDeschis = false;
        }
    }

    public void ExitPause()
    {
        meniuDeschis = false;
        pauseMenu.SetActive(false);
        Time.timeScale=1;
    }

    public void ToMenu()
    {
        meniuDeschis = false;
        Time.timeScale=1;
        pauseMenu.SetActive(false);
        StartCoroutine(TransitionMenu());
    }

    public void Play()
    {
        StartCoroutine(Transition());
    }

    public void RegularPlay()
    {
        if(sawTutorial) Play();
        else askToContinue.SetActive(true);
    }
    public void Sunet()
    {
        Instantiate(sunetGo);
    }
    public void SunetPWR()
    {
        Instantiate(sunetPWRGo);
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator Transition()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Main");
    }

    IEnumerator TransitionMenu()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
