using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    private Dictionary<string, Action> CommandAction = new Dictionary<string, Action>();
    private KeywordRecognizer CommandRecognizer;

	// Backfround Sound sources
    public AudioSource Audiosource;
    public AudioClip Song;

        void Start()
    {

        Audiosource.clip = Song;
        Audiosource.Play();
        //Audiosource.PlayOneShot(Song);


        CommandAction.Add("change", ChangeCommand);

        CommandRecognizer = new KeywordRecognizer(CommandAction.Keys.ToArray());
        CommandRecognizer.OnPhraseRecognized += OnCommandRecognized;
        CommandRecognizer.Start();

    }

    private void OnCommandRecognized(PhraseRecognizedEventArgs args)
    {

        CommandAction[args.text].Invoke();
    }

    private void ChangeCommand()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Command Recognized!");
    }
}
