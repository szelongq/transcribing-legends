using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    ScoreUIManager scoreUIManager;

    public int currentScore;
    public int currentCombo;

    public int correctChars;
    public int wrongChars;
    public int maxCombo;

    public float accuracy;

    // Start is called before the first frame update
    void Awake()
    {
        ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        scoreUIManager.SetScore(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
        currentCombo = 0;
        correctChars = 0;
        wrongChars = 0;
        maxCombo = 0;
    }

    public void addCorrectChar()
    {
        currentCombo += 1;
        maxCombo = Math.Max(maxCombo, currentCombo);
        correctChars += 1;
        currentScore += currentCombo * 10;
        accuracy = GetAccuracy();
    }

    public void addWrongChar()
    {
        currentCombo = 0;
        wrongChars += 1;
        accuracy = GetAccuracy();
    }

    public int GetScore()
    {
        return currentScore;
    }

    public int GetMaxCombo()
    {
        return maxCombo;
    }

    public float GetAccuracy()
    {
        if (correctChars + wrongChars == 0)
        {
            return 100f;
        }
        else
        {
            return ((float) correctChars / (correctChars + wrongChars)) * 100;
        }
    }

    public float GetGrossWPM(float duration)
    {
        return ((float) (correctChars + wrongChars) / 5) * 60 / duration;
    }

    public float GetNetWPM(float duration)
    {
        return (((float) (correctChars + wrongChars) / 5) - wrongChars) * 60 / duration;
    }

    public string GetFullSummary(float duration)
    {
        return string.Format("Score: {0}, Max Combo: {1}, Accuracy: {2:F2}%, Gross WPM: {3:F0}, Net WPM: {4:F0}, correctChars: {5}, wrongChars: {6}", 
            currentScore, maxCombo, accuracy, GetGrossWPM(duration), GetNetWPM(duration), correctChars, wrongChars);
    }

}
