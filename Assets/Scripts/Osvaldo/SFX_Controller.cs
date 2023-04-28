using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Controller : MonoBehaviour
{
    AudioSource m_AudioSource;
    public AudioClip[] SFXAudios;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
    public void PlayAudio(int index)
    {
        m_AudioSource.clip = SFXAudios[index];
        m_AudioSource.Play();
    }
}
