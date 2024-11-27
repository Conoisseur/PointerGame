using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUZIKSKRIPT : MonoBehaviour
{
    public AudioSource main;
    public AudioSource cymbal;
    public AudioSource marimba;
    public AudioSource clock;

    //INITIALLY ONLY THE MAIN SOUNDTRACK PLAYS. THE THREE PERCUSSION TRACKS COME IN WHEN EACH OF THE FIRST THREE STEPS OF THE PUZZLE ARE SOLVED
    public void Start()
    {
        main.volume = 1f;
        cymbal.volume = 0f;
        marimba.volume = 0f;
        clock.volume = 0f;
    }

    /*
     
    PLEASE SOMEONE FIX THESE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
    
    //THIS METHOD SHOULD BE CARRIED OUT WHEN THE SECRET MESSAGE IS FOUND:
    public void OnFindingHiddenMessage()
    {
        StartCoroutine(VolumeOn(bassDrum));
    }

    //THIS METHOD SHOULD BE CARRIED OUT WHEN THE HIDDEN OBJECT IS FOUND:
    public void OnFindingHiddenObject()
    {
        StartCoroutine(VolumeOn(marimba));
    }

    //THIS METHOD SHOULD BE CARRIED OUT WHEN THE ALPHABET/SCRIPT THING IS COMPLETED???
    public void OnAlphabetScriptThing()
    {
        StartCoroutine(VolumeOn(clock));
    }
    */

    //COROUTINE FOR TURNING ON THE VOLUME OF THE PERCUSSION TRACKS:
    IEnumerator VolumeChange(AudioSource audioSource)
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.05f);
            audioSource.volume += 0.05f;
        }
    }
}
