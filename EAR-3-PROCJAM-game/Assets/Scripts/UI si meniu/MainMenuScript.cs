using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject transition;
    public GameObject pauseMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "MainMenu")
        {
            Time.timeScale=0;
            pauseMenu.SetActive(true);
        }
    }

    public void ExitPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale=1;
    }

    public void ToMenu()
    {
        Time.timeScale=1;
        pauseMenu.SetActive(false);
        StartCoroutine(TransitionMenu());
    }

    public void Play()
    {
        StartCoroutine(Transition());
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
