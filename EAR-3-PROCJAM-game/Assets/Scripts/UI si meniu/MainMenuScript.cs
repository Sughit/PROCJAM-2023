using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject transition;

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
}
