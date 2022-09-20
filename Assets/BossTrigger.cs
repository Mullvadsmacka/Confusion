using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{

    [SerializeField] private float timer;

    [SerializeField] private GameObject wall;

    [SerializeField] private Camera cameraComponent;

[SerializeField] private GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true);
        {
            CutScene();
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            
        }
    }


private void CutScene()
{

        Debug.Log("What why?");
    player.GetComponent<Player>().canMove = false;
     cameraComponent.orthographicSize = 8;
}
    private void StartBoss()
    {
       

    }
    
}
