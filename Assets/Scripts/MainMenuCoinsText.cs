using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainMenuCoinsText : MonoBehaviour
{
    [SerializeField] private TMP_Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = "Cheese collected: " + PlayerPrefs.GetInt("CoinsAmount");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
