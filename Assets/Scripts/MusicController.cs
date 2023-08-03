using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    AudioSource m_AudioSource;
    public AudioClip[] MusicAudios;

    private void Start()
    {
        m_AudioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }
    public void PlayAudio(int index)
    {
        m_AudioSource.clip = MusicAudios[index];
        m_AudioSource.Play();
    }
}
