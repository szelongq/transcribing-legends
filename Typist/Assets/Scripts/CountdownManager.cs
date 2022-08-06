using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownManager : MonoBehaviour
{

    [SerializeField]
    TMP_Text countdownText;

    [SerializeField]
    GameManager gameManager;

    bool isCountingDown;
    float countdownTime;
    const float COUNTDOWN_TIME = 3f;

    void Awake()
    {
        isCountingDown = false;
        countdownTime = 0f;
    }

    void Start()
    {
        StartCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountingDown)
        {
            countdownTime -= Time.deltaTime;
            if (countdownTime <= 0f)
            {
                StopCountdown();
            }

            DisplayCountdown(countdownTime);
        }

    }

    public void StartCountdown()
    {
        isCountingDown = true;
        countdownTime = COUNTDOWN_TIME;
    }

    public void StopCountdown() {
        isCountingDown = false;
        countdownTime = 0f;
        gameManager.ResumeGame();
        gameObject.SetActive(false);
    }

    void DisplayCountdown(float timeLeft)
    {
        countdownText.text = string.Format("{0}", Mathf.CeilToInt(timeLeft));
    }
}
