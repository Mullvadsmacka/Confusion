using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Coin : MonoBehaviour
{

    [SerializeField] private ParticleSystem particels;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupClip;


    private bool canPickupCoin = true;

    private bool removeGameObjects = false;
    private float timer = 0f;
    [SerializeField] private float timeBeforeDeletion = 1f;

    private void Update()
    {
        if (removeGameObjects == true)
        {
            timer += Time.deltaTime;
            if (timer > timeBeforeDeletion)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if (canPickupCoin == true)
            {
                collision.GetComponent<PlayerState>().PickCoin();
                spriteRenderer.sprite = null;
                animator.enabled = false;
                particels.Play();
                removeGameObjects = true;
                canPickupCoin = false;
//                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.PlayOneShot(pickupClip);
            }
        }
    }
}