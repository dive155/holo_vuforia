using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class VoiceRecognitionScript : MonoBehaviour
{
    [SerializeField] 
	private string[] keywords = new string[] { "done", "exit" };

    private KeywordRecognizer recognizer;

    void Start()
    {
		recognizer = new KeywordRecognizer(keywords);
		recognizer.OnPhraseRecognized += OnPhraseRecognized;
		recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        string recognizedWord = args.text;
        if(recognizedWord == keywords[0])
        {
			EventManager.OnDoneRecognized();
        }
        else if(recognizedWord == keywords[1])
        {
            Application.Quit();
        }
    }
}