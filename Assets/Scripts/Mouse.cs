using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Mouse : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    [SerializeField] private GameObject convo;

    [SerializeField] private string questText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip squeek;


    void Start()
    {
        convo.SetActive(false);

        text.text = questText;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {

            convo.SetActive(true);
            audioSource.PlayOneShot(squeek);
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            ;
            convo.SetActive(false);
        }
    }

}
