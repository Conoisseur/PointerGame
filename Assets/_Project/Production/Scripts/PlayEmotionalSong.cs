using UnityEngine;

public class PlayEmotionalSong : MonoBehaviour
{
    public AudioClip emotionalSong; // Reference to the WAV file (AudioClip)
    private AudioSource _audioSource; // Reference to the AudioSource component
    private bool hasPlayed = false; // Tracks whether the song has been played

    private void Start()
    {
        // Add an AudioSource component if it doesn't already exist
        _audioSource = gameObject.GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the AudioClip to the AudioSource
        if (emotionalSong != null)
        {
            _audioSource.clip = emotionalSong;
        }
        else
        {
            Debug.LogError("AudioClip 'emotional song' is not assigned!");
        }

        // Optional: Configure AudioSource settings
        _audioSource.playOnAwake = false; // Ensure the sound doesn't play automatically
        _audioSource.loop = false;       // Play the sound only once
    }

    private void OnMouseDown()
    {
        // Play the song only if it hasn't already been played
        if (!hasPlayed && _audioSource != null && emotionalSong != null)
        {
            _audioSource.Play();
            hasPlayed = true; // Mark the song as played
            Debug.Log("Playing 'emotional song'.");
        }
        else if (hasPlayed)
        {
            Debug.Log("Song has already been played. Ignoring further clicks.");
        }
    }
}
