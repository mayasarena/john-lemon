using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public CanvasGroup timesUpImage;
    public AudioSource exitAudio;
    public AudioSource caughtAudio;
    bool m_HasAudioPlayed;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    bool m_IsTimeUp;
    float m_Timer;

    void OnTriggerEnter(Collider other) // check if player is at exit
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer() // player is caught by an enemy
    {
        m_IsPlayerCaught = true;
    }

    public void TimesUp() // time is up
    {
        m_IsTimeUp = true;
    }

    void Update() // display appropriate images 
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, exitAudio);
        }

        else if(m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, caughtAudio);
        }

        else if(m_IsTimeUp)
        {
            EndLevel(timesUpImage, caughtAudio);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, AudioSource audioSource) 
    {
        if(!m_HasAudioPlayed) // play the audio if it hasn't been played yet
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration)
        {
            SceneManager.LoadScene(0); // return to main menu
        }
    }
}
