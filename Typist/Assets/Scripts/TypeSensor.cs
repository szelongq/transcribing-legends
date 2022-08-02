using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeSensor : MonoBehaviour
{

    string targetWord;
    int index;

    [SerializeField]
    TypingWordUIManager wordUIManager;

    [SerializeField]
    WordBankManager wordBankManager;

    // Start is called before the first frame update
    void Start()
    {
        startNewWord();
    }

    void startNewWord()
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
        }
        else
        {
            wordUIManager.addWrongLetter(c);
        }
        index += 1;
    }

    void Update()
    {
        if (Input.inputString.Length > 0)
        {
            Debug.Log("Typed: " + Input.inputString);
        }

        foreach(char c in Input.inputString)
        {
            if (char.IsLetter(c))
            {
                checkLetter(c);
            }
        }
    }

    // void OnGUI()
    // {
    //     Event e = Event.current;
    //     if (e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1 && char.IsLetter(e.keyCode.ToString()[0]))
    //     {
    //         Debug.Log("Detected key code: " + e.keyCode);
    //         checkLetter(e.keyCode.ToString()[0]);
    //     }
    // }
}
