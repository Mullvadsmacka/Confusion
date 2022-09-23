using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorConstrain : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    
     {
           /* Debug.Log("HEJEHEHE"); */
         if (collision.gameObject.CompareTag("Player") == true)
         {

           
             collision.gameObject.transform.SetParent(gameObject.transform);
             /* Debug.Log("lessgo"); */
         }
     }


     private void OnCollisionExit2D(Collision2D collision)
     {
         if (collision.gameObject.CompareTag("Player") == true)
         {
             collision.gameObject.transform.parent = null;
         }
     }

     
}
