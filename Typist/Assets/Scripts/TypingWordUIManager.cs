using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingWordUIManager : MonoBehaviour
{
    public TMP_Text targetWordText;
    public TMP_Text typedWordText;
    public TMP_Text sourceText;

    Word targetWord;
    string typedWord;
    string remWord; // remaining word
    string source;

    // Start is called before the first frame update
    void Awake()
    {
        targetWord = new Word("", "");
    }

    // Update is called once per frame
    void Update()
    {
        targetWordText.text = targetWord.word;
        typedWordText.text = typedWord;
        sourceText.text = "-" + targetWord.source;
    }

    public void loadTargetWord(Word word)
    {

        targetWord = word;
        typedWord = "";
        remWord = word.word;

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
