using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    string targetWord;
    int index;
    bool isPaused;
    const float GAME_DURATION = 30;

    [SerializeField]
    GameObject pausePanel;

    [SerializeField]
    CountdownManager countdownManager;

    [SerializeField]
    TypingWordUIManager wordUIManager;

    [SerializeField]
    WordBankManager wordBankManager;

    [SerializeField]
    TimerUIManager timeManager;

    [SerializeField]
    ScoreManager scoreManager;

    [SerializeField]
    ResultsUIManager resultsManager;

    [SerializeField]
    AudioManager audioManager;

    // Start is called before the first frame update
    void Awake()
    {
        targetWord = "";
        index = 0;
        isPaused = true;
    }

    public void StartGame()
    {
        scoreManager.ResetScore();
        startNewWord();
        timeManager.SetTimer(GAME_DURATION);
        Debug.Log("Game Starting");
        countdownManager.gameObject.SetActive(true);
        countdownManager.StartCountdown();
        audioManager.PlayInGameBGM();

    }

    public void PauseGame()
    {
        timeManager.PauseTimer();
        isPaused = true;
    }

    public void ResumeGame()
    {
        timeManager.ResumeTimer();
        isPaused = false;
    }

    public void EndGame()
    {
        isPaused = true;
        Debug.Log("Game Over");
        float totalTime = timeManager.GetTotalTime();
        int score = scoreManager.GetScore();
        int maxCombo = scoreManager.GetMaxCombo();
        float accuracy = scoreManager.GetAccuracy();
        float grossWPM = scoreManager.GetGrossWPM(totalTime);
        float netWPM = scoreManager.GetNetWPM(totalTime);
        Debug.Log(scoreManager.GetFullSummary(totalTime));
        resultsManager.ShowResults(score, maxCombo, accuracy, grossWPM, netWPM);
        audioManager.PlayResultsBGM();
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void startNewWord()
    {
        Word wordToType = wordBankManager.GetRandomWord();
        targetWord = wordToType.word;
        index = 0;
        wordUIManager.loadTargetWord(wordToType);
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
            // wordUIManager.addWrongLetter(c);
            scoreManager.addWrongChar();
        }
        index += 1;
    }

    void Update()
    {
        if (isPaused && pausePanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
            pausePanel.SetActive(false);
            return;
        }

        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
                pausePanel.SetActive(true);
                return;
            }
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
