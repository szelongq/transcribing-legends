using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WordBankManager : MonoBehaviour
{

    public const string wordBankFolderName = "WordBank";
    public const string wordBankFileName = "WordBank.json";

    string wordBankDir;
    string wordBankFile;

    WordBank wordBank;

    Word[] currWordLib;

    void Awake()
    {
        wordBankDir = Path.Combine(Application.streamingAssetsPath, wordBankFolderName);
        wordBankFile = Path.Combine(Application.streamingAssetsPath, wordBankFolderName,
            wordBankFileName);  // WordBank/WordBank.json

        LoadWordBankFromLocal();
        // LoadWordBankFromWeb();

        UseNormalWordLib();
    }

    public Word GetRandomWord()
    {
        return currWordLib[Random.Range(0, currWordLib.Length)];
    }

    public bool LoadWordBankFromLocal()
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
            return true;
        }
        else
        {
            Debug.Log("WordBank file not found in " + wordBankFile);
            return false;
        }
    }

    public IEnumerator LoadWordBankFromWeb()
    {
        yield return StartCoroutine(GetRequest(wordBankFile));
    }

    // Taken from Unity Docs example code
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    LoadWordBank(webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    public void LoadWordBank(string wordBankJson)
    {
        // Deserialize JSON
            wordBank = JsonUtility.FromJson<WordBank>(wordBankJson);
    }

    public void SaveWordBank()
    {
        // creates WordBank folder if not exists
        Directory.CreateDirectory(wordBankDir);    

        // Serialize to JSON
        string wordBankJson = JsonUtility.ToJson(wordBank);

        // Write JSON to file.
        File.WriteAllText(wordBankFile, wordBankJson);
    }

    public void UseNormalWordLib()
    {
        currWordLib = wordBank.words;
    }

    public void UsePokemonNoisesWordLib()
    {
        currWordLib = wordBank.pokemonNoises;
    }
}

