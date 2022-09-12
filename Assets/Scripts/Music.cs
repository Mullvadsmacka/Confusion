using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip musicClip;

    void Start()
    {
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
