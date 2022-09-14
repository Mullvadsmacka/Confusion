using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;

    private int routeToGo;

    private float tParam;

    private Vector3 objectPosition;

    private float speedModifier;

    private bool coroutineAllowed;

    Quaternion lookRotation;
    Vector3 direction;

    public float rotSpeed = 360f;

    // Start is called before the first frame update
    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.5f;
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        
      

        if (coroutineAllowed)
        {


           
            StartCoroutine(GoByTheRoute(routeToGo));
        }
    }

    private IEnumerator GoByTheRoute(int routeNum)
    {
        coroutineAllowed = false;

        Vector2 p0 = routes[routeNum].GetChild(0).position;
        Vector2 p1 = routes[routeNum].GetChild(1).position;
        Vector2 p2 = routes[routeNum].GetChild(2).position;
        Vector2 p3 = routes[routeNum].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            /*
              Vector3 diff = objectPosition - transform.position;
        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

             */


            /*  Vector3 dir = objectPosition - transform.position;
              dir.y = 0;                                          // if you want in sepecific directions only or its optional 
              transform.rotation = Quaternion.LookRotation(dir);
              transform.position = objectPosition;
            */


            /*
            Vector2 test = objectPosition - transform.position;

            float rotSpeed = 360;

            Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(test), rotSpeed * Time.deltaTime);
            transform.rotation = rot;
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

            */






            objectPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

            // transform.LookAt(objectPosition);


            // Quaternion diff = transform.rotation.z - objectPosition;

            /*
                float angle = Mathf.Atan2(objectPosition.y, objectPosition.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler( new Vector3(0, 0, angle));
            */

            /*
            
               Vector3 D = objectPosition - transform.position;
            Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(D), rotSpeed * Time.deltaTime);
            transform.rotation = rot;
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
            
            */

            /*
             direction = (objectPosition - transform.position).normalized;

            lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotSpeed);
            */

            
            Vector3 dir = objectPosition - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            



            transform.position = objectPosition;
yield return new WaitForEndOfFrame();
}

tParam = 0f;

routeToGo += 1;

if (routeToGo > routes.Length - 1)
{
routeToGo = 0;
}

coroutineAllowed = true;

}
}
