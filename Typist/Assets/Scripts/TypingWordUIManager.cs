using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingWordUIManager : MonoBehaviour
{
    public TMP_Text targetWordText;
    public TMP_Text typedWordText;

    string targetWord;
    string typedWord;
    string remWord; // remaining word

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetWordText.text = targetWord;
        typedWordText.text = "<b>" + typedWord + "</b>";
    }

    public void loadTargetWord(string word)
    {
        targetWord = word;
        typedWord = "";
        remWord = word;
    }

    public void addCorrectLetter(char c)
    {
        typedWord += "<color=green>" + c + "</color>";
        remWord = remWord.Substring(1);
    }

    public void addWrongLetter(char c)
    {
        typedWord += "<color=red>" + c + "</color>";
        remWord = remWord.Substring(1);
    }
    
}
