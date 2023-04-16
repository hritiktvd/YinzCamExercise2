using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource BackgroundMusic;

    private void OnEnable()
    {
        EventsManager.onPortalEnter += playAudio;
        EventsManager.onPortalExit += stopAudio;
    }

    private void OnDisable()
    {
        EventsManager.onPortalExit -= stopAudio;
    }
    // Start is called before the first frame update
    void Start()
    {
        BackgroundMusic = GetComponent<AudioSource>();
    }

    private void playAudio()
    {
        BackgroundMusic.Play(0);
        EventsManager.onPortalEnter -= playAudio;
        Debug.Log("Audio Played");
    }

    private void stopAudio()
    {
        BackgroundMusic.Stop();
        EventsManager.onPortalEnter += playAudio;
        Debug.Log("Audio Stopped");
    }
}
