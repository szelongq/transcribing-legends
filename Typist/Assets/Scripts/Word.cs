using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;

    public string source;

    public Word(string word, string source)
    {
        this.word = word;
        this.source = source;
    }
    
}
