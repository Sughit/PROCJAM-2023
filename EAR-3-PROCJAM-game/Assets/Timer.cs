using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public float gameTime;
    float time;
    public bool stopTimer = false;
    void Start()
    {
        
    }

    public void StartTimer()
    {
        
        StartCoroutine(Timp());
    }

    IEnumerator Timp()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        while (!stopTimer)
        {
            gameTime -=Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if(gameTime <= 0)
                {
                    stopTimer = true;
                    this.gameObject.SetActive(false);
                }

            if(!stopTimer)
                timerSlider.value = gameTime;
        }
    }
}
