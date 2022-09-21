using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BossBody : MonoBehaviour
{
    [SerializeField] private GameObject brain;

    private Vector3 objectPosition;
    private void Start()
    {
        objectPosition = brain.GetComponent<BezierFollow>().objectPosition;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = objectPosition - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
