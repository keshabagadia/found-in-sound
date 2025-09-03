using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPhoneme : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource component not found on this GameObject.");
        }
    }
    public void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            Debug.Log(gameObject.name + " is playing audio.");
        }
        else
        {
            Debug.LogWarning("AudioSource is not assigned.");
        }
    }

}
