using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{

    GameObject objectToKill;

    // Start is called before the first frame update
    void Start()
    {

        objectToKill = gameObject.transform.parent.gameObject;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") == true)
        {
            if (collision.GetComponent<Player>().isGrounded == false)
            {
                Destroy(objectToKill);
            }

        }
    }


}
