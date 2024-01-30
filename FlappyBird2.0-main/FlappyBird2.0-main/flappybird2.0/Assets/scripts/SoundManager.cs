using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audiosource;
    public static SoundManager instance;


   

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audiosource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioClip)
    {
        audiosource.PlayOneShot(audioClip);
    }

    public void StopAudio()
    {

    }
}
