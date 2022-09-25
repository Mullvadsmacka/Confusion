using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitboxBoss : MonoBehaviour
{
    [SerializeField] private GameObject UICanvas;
    [SerializeField] private GameObject Credits;
    [SerializeField] private GameObject cameraComponent;
    [SerializeField] private float timer;
    private bool activeTimer = false;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player") == true)
        {
            
            cameraComponent.GetComponent<Kamera>().followTarget = gameObject;
            cameraComponent.GetComponent<Kamera>().smoothSpeed = 1000;
           collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //collision.gameObject.GetComponent<PlayerState>().Respawn();
            //M�ste restarta level ocks�
            activeTimer = true;
            UICanvas.SetActive(false);


        }

      
    }
    void Update()
    {
        if (activeTimer == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
               
                Credits.SetActive(true);
              //  SceneManager.LoadScene(1);
            }
        }
    }
}
