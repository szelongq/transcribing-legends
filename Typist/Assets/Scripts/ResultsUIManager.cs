using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultsUIManager : MonoBehaviour
{
    [SerializeField]
    GameObject resultsPanel;

    [SerializeField]
    TMP_Text scoreValueText;
    [SerializeField]
    TMP_Text maxComboValueText;
    [SerializeField]
    TMP_Text accuracyValueText;
    [SerializeField]
    TMP_Text grossWPMValueText;
    [SerializeField]
    TMP_Text netWPMValueText;

    public void Awake()
    {
        scoreValueText.text = "-";
        maxComboValueText.text = "-";
        accuracyValueText.text = "-";
        grossWPMValueText.text = "-";
        netWPMValueText.text = "-";
    }

    public void ShowResults(int score, int maxCombo, float accuracy, float grossWPM, float netWPM)
    {
        resultsPanel.SetActive(true);
        scoreValueText.text = string.Format("{0}", score);
        maxComboValueText.text = string.Format("{0}", maxCombo);
        accuracyValueText.text = string.Format("{0:F2}%", accuracy);
        grossWPMValueText.text = string.Format("{0:F0}", grossWPM);
        netWPMValueText.text = string.Format("{0:F0}", netWPM);
    }
}
