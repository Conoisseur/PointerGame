using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUZIKSKRIPT : MonoBehaviour
{
    public AudioSource main;
    public AudioSource cymbal;
    public AudioSource marimba;
    public AudioSource clock;
    public AudioSource victory;
    public AudioSource clueComplete;

    //INITIALLY ONLY THE MAIN SOUNDTRACK PLAYS. THE THREE PERCUSSION TRACKS COME IN WHEN EACH OF THE FIRST THREE STEPS OF THE PUZZLE ARE SOLVED
    public void Start()
    {
        main.volume = 1f;
        cymbal.volume = 0f;
        marimba.volume = 0f;
        clock.volume = 0f;
    }



    //PLEASE SOMEONE FIX THESE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 

    //THIS SHOULD BE CARRIED OUT WHEN THE SECRET MESSAGE IS FOUND:
    public void OnFindingHiddenMessage()
    {
        StartCoroutine(VolumeChange(cymbal));
    }

    //THIS SHOULD BE CARRIED OUT WHEN THE HIDDEN OBJECT IS FOUND:
    public void OnFindingHiddenObject()
    {
        StartCoroutine(VolumeChange(marimba));
    }

    //THIS SHOULD BE CARRIED OUT WHEN THE ALPHABET/SCRIPT THING IS COMPLETED???
    public void OnAlphabetScriptThing()
    {
        StartCoroutine(VolumeChange(clock));
    }

    //THIS SHOULD BE CARRIED OUT WHEN THE PLAYER COMPLETES A CLUE:
    public void OnClueComplete()
    {
        StartCoroutine(Victory());
    }

    //THIS SHOULD BE CARRIED OUT WHEN THE PLAYER ESCAPES:
    public void OnVictory()
    {
        StartCoroutine(Victory());
    }

    //COROUTINE FOR TURNING ON THE VOLUME OF THE PERCUSSION TRACKS:
    IEnumerator VolumeChange(AudioSource audioSource)
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.05f);
            audioSource.volume += 0.05f;
        }
    }

    //COROUTINE FOR SOUND ON CLUE COMPLETED:
    IEnumerator ClueComplete()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.05f);
            main.volume -= 0.025f;
            cymbal.volume -= 0.025f;
            marimba.volume -= 0.025f;
            clock.volume -= 0.025f;
        }
        clueComplete.Play();
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.05f);
            main.volume += 0.025f;
            cymbal.volume += 0.025f;
            marimba.volume += 0.025f;
            clock.volume += 0.025f;
        }
    }

    //COROUTINE FOR SOUND ON VICTORY:
    IEnumerator Victory()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.05f);
            main.volume -= 0.05f;
            cymbal.volume -= 0.05f;
            marimba.volume -= 0.05f;
            clock.volume -= 0.05f;
        }
        victory.Play();
    }
}
