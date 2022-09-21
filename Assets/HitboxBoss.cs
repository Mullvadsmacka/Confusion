using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitboxBoss : MonoBehaviour
{
    [SerializeField] private GameObject cameraComponent;
    [SerializeField] private float timer;
    private bool activeTimer = false;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player") == true)
        {

            cameraComponent.GetComponent<Kamera>().followTarget = gameObject;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //collision.gameObject.GetComponent<PlayerState>().Respawn();
            //Måste restarta level också

          
        }

        void Update()
        {
            if(activeTimer == true)
            {
                timer -= Time.deltaTime;
                if(timer <= 0)
                {
                   // SceneManager.SetActiveScene(1);
                }
            }
        }
    }
}
