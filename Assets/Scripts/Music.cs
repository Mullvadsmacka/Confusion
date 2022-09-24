using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip musicClip;



    void Start()
    {

        DontDestroyOnLoad(gameObject);
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
