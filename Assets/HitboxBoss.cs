using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxBoss : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player") == true)
        {
            
            collision.gameObject.GetComponent<PlayerState>().Respawn();
            //Måste restarta level också
        }
    }
}
