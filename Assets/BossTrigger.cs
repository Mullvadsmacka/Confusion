using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{

    [SerializeField] private float timer;

    [SerializeField] private GameObject wall;

    [SerializeField] private Camera cameraComponent;

    [SerializeField] private GameObject boss;

    [SerializeField] private float speed;

    private bool activeTimer = false;

[SerializeField] private GameObject player;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip monsterRoar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
         
            CutScene();
        }
    }

    private void Update()
    {
        if (activeTimer == true)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                StartBoss();
                activeTimer = false;
            }
        }
       
    }


private void CutScene()
{
    
       
    player.GetComponent<Player>().canMove = false;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        player.GetComponent<Player>().animator.SetBool("Walking", false);
        cameraComponent.fieldOfView = 100;
        activeTimer = true;

}
    private void StartBoss()
    {
        audioSource.PlayOneShot(monsterRoar);
        boss.GetComponent<BezierFollow>().speedModifier = speed;

    }
    
}
