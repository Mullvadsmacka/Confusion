using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{


    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            // if (collision.GetComponent<Quest>().isQuestComplete == true)
            //  {
            Debug.Log("Next Level");
            GameObserver.SaveCoinsToMemory(collision.GetComponent<PlayerState>().coins);
            SceneManager.LoadScene(0);
            //  }
        }





    }
}
