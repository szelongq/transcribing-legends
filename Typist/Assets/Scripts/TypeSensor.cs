using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeSensor : MonoBehaviour
{

    string targetWord;
    int index;
    bool isPaused;

    [SerializeField]
    TypingWordUIManager wordUIManager;

    [SerializeField]
    WordBankManager wordBankManager;

    [SerializeField]
    TimerUIManager timeManager;

    [SerializeField]
    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Awake()
    {
        targetWord = "";
        index = 0;
        isPaused = true;
    }

    public void StartGame()
    {
        startNewWord();
        isPaused = false;
        Debug.Log("Game Start");
    }

    public void PauseGame()
    {
        isPaused = true;
    }

    public void ResumeGame()
    {
        isPaused = false;
    }

    public void EndGame()
    {
        isPaused = true;
        Debug.Log("Game Over");
        int score = scoreManager.GetScore();
        int highestCombo = scoreManager.GetHighestCombo();
        float accuracy = scoreManager.GetAccuracy();
        float grossWPM = scoreManager.GetGrossWPM(timeManager.GetTotalTime());
        float netWPM = scoreManager.GetNetWPM(timeManager.GetTotalTime());
        Debug.Log(string.Format("Score: {0:00000000}, MaxCombo: {1}, Accuracy: {2:F2}%, Gross WPM: {3:F0}, Net WPM: {4:F0}", 
            score, highestCombo, accuracy, grossWPM, netWPM));
    }

    public void startNewWord()
    {
        targetWord = wordBankManager.getRandomWord();
        index = 0;
        wordUIManager.loadTargetWord(targetWord);
    }

    void checkLetter(char c)
    {
        if (index >= targetWord.Length)
        {
            startNewWord();
            return;
        }

        Debug.Log("Comparing " + targetWord[index] + " with " + c);

        if (c == targetWord[index])
        {
            wordUIManager.addCorrectLetter(c);
            scoreManager.addCorrectChar();
        }
        else
        {
            wordUIManager.addWrongLetter(targetWord[index]);
            scoreManager.addWrongChar();
        }
        index += 1;
    }

    void Update()
    {
        if (!isPaused)
        {
            if (Input.inputString.Length > 0)
            {
                Debug.Log("Typed: " + Input.inputString);
            }

            foreach(char c in Input.inputString)
            {
                checkLetter(c);
            }

            if (timeManager.IsTimesUp())
            {
                EndGame();
            }
        }
    }
}
