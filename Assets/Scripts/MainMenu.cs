using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   

    public void StartButton()
    {
        //PlayerPrefs.SetInt("CoinsAmount", 0) ;
       
        SceneManager.LoadScene("Level02");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
