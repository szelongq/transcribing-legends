using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUIManager : MonoBehaviour
{

    [SerializeField]
    TMP_Text timerText;

    bool isTimerRunning;
    float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        isTimerRunning = false;
        timeLeft = 0f;
        StartTimer(5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0f)
            {
                StopTimer();
            }
        }

        DisplayTime(timeLeft);
    }

    public void StartTimer(float timeGiven)
    {
        timeLeft = timeGiven;
        isTimerRunning = true;
    }

    public void StopTimer() 
    {
        isTimerRunning = false;
        timeLeft = 0f;

    }

    void DisplayTime(float timeLeft)
    {
        int minutes = Mathf.FloorToInt(timeLeft/60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        int milli = Mathf.FloorToInt(timeLeft * 100 % 100);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milli);
    }
}
