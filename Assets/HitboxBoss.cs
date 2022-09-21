using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxBoss : MonoBehaviour
{
    [SerializeField] private GameObject cameraComponent;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player") == true)
        {

            cameraComponent.GetComponent<Kamera>().followTarget = gameObject;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //collision.gameObject.GetComponent<PlayerState>().Respawn();
            //Måste restarta level också
          
        }
    }
}
