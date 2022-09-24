using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 1.5f;
    [SerializeField] private float boost;
    private Player playerMovement;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupClip;


    private bool isUsingMovementSpeed = false;
    private float timer = 0f;
    [SerializeField] private float timeBeforeReset;

    void Update()
    {
        if (isUsingMovementSpeed == true)
        {
            Debug.Log("True");
            timer += Time.deltaTime;
            if (timer >= timeBeforeReset)
            {
                Debug.Log("Timer Klar");
                playerMovement.returnToNormalSpeed();
                timer = 0f;
                isUsingMovementSpeed = false;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

            if (collision.CompareTag("Player") == true)
            {
                if (playerMovement == null)
                {
                    playerMovement = collision.GetComponent<Player>();
                }
                timer = 0f;
                isUsingMovementSpeed = true;
                Debug.Log("Sppeeeeeeed");
                playerMovement.GetSpeedBoost(boost);
            //playerMovement.GetSpeedBoost(speedMultiplier);
            audioSource.PlayOneShot(pickupClip);
        }
        
    }

}
