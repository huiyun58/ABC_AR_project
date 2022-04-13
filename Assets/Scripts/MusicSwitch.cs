using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// allow user to turn on/off the music when calling this function
public class MusicSwitch : MonoBehaviour
{
    AudioSource m_MyAudioSource;

    void Start()
    {
        m_MyAudioSource = GameObject.Find("background_music").GetComponent<AudioSource>();

    }

    public void music_on_off()
    {
        
        if (m_MyAudioSource.isPlaying)
        {
            m_MyAudioSource.Pause();
        }
        else
        {
            m_MyAudioSource.Play();
        }

    }
    
}
