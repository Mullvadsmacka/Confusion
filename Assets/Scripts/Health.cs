using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public PlayerState playerState;

    private Slider slider;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
         health = playerState.health;
        slider = gameObject.GetComponent<Slider>();
        slider.wholeNumbers = true;
        slider.maxValue = health;
       
    }

    // Update is called once per frame
    void Update()
    {
         
         slider.value = playerState.health;


    }
}
