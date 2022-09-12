using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Coin : MonoBehaviour
{
    private TMP_Text textComponent;

    private PlayerState playerState;
    // Start is called before the first frame update
    void Start()
    {
       playerState = GameObject.Find("Player").GetComponent<PlayerState>();
        textComponent = gameObject.GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
       textComponent.text = playerState.coins + "";
    }
}
