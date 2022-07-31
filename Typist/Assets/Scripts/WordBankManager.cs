using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordBankManager : MonoBehaviour
{

    public const string wordBankFolderName = "WordBank";
    public const string wordBankFileName = "WordBank.json";

    string wordBankDir;
    string wordBankFile;

    [SerializeField]
    WordBank wordBank;

    void Awake()
    {
        wordBankDir = Path.Combine(Application.streamingAssetsPath, wordBankFolderName);
        wordBankFile = Path.Combine(Application.streamingAssetsPath, wordBankFolderName,
            wordBankFileName);  // WordBank/WordBank.json
    }

    void Start()
    {
        loadWordBank();
    }

    public void loadWordBank()
    {
        // creates WordBank folder if not exists
        Directory.CreateDirectory(wordBankDir);    

        // Does the file exist?
        if (File.Exists(wordBankFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(wordBankFile);

            // Deserialize JSON
            wordBank = JsonUtility.FromJson<WordBank>(fileContents);

            Debug.Log("WordBank loaded: " + wordBank);
        }
        else
        {
            Debug.Log("WordBank file not found in " + wordBankFile);
        }
    }

    public void saveWordBank()
    {
        // creates WordBank folder if not exists
        Directory.CreateDirectory(wordBankDir);    

        // Serialize to JSON
        string wordBankJson = JsonUtility.ToJson(wordBank);

        // Write JSON to file.
        File.WriteAllText(wordBankFile, wordBankJson);
    }
}

