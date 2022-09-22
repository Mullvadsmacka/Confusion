using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public int health = 5;
    public int maxHealth;

    public static int coins = 0;

    [SerializeField] private GameObject startPosition;
    [SerializeField] private bool useStartPosition = true;
    private GameObject respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (useStartPosition == true)
        {
            gameObject.transform.position = startPosition.transform.position;
        }

        respawnPoint = startPosition;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }




    public void TakeDmg(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
         
            Respawn();
        }
    }

    public void Respawn()
    {
        health = maxHealth;
        gameObject.transform.position = respawnPoint.transform.position;
    }

    public void PickCoin()
    {
        coins++;
    }


    public void ChangeRespawnPosition(GameObject newRespawnPosition)
    {
        respawnPoint = newRespawnPosition;

    }


}
