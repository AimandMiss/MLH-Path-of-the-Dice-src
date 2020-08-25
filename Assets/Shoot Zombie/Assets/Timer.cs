using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float currentTime = 0f;
    public float startingtime = 10f;
    public Slider slider;
    public int winorloss;


    public void SetMaxTime(float time)
    {
        slider.maxValue = time;
        slider.value = time;
    }

    public void SetTime(float time)
    {
        slider.value = time;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingtime;
        SetMaxTime(currentTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        SetTime(currentTime);
        if (currentTime <= 0)
        {
            winorloss = 1;
            Data.minigameWin = true;
            Time.timeScale = 0;
        }
    }
    public int winningson()
    {
        return winorloss;
    }
    public float yaknowthetime()
    {
        return currentTime;
    }
}
