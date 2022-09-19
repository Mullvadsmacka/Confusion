using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{

    [SerializeField] private float timer;

    [SerializeField] private GameObject wall;

    [SerializeField] private Camera cameraComponent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true);
        {

        }
    }

    private void Update()
    {
        
    }

    private void StartBoss()
    {
        cameraComponent.orthographicSize = 8;
    }
    
}
