using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreValueText;

    int score;

    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreValueText.text = string.Format("{0:00000000}", score);
    }

    public void SetScore(int newScore)
    {
        score = newScore;
    }
}
