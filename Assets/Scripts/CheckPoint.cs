using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
 
 [SerializeField] private Sprite checkPointTaken;
 private void OnTriggerEnter2D(Collider2D collision)
 {
     if(collision.gameObject.CompareTag("Player") == true)
     {
         collision.gameObject.GetComponent<PlayerState>().ChangeRespawnPosition(gameObject);
         gameObject.GetComponent<SpriteRenderer>().sprite = checkPointTaken;
     }
 }

}
