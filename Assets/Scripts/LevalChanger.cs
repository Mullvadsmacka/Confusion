using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevalChanger : MonoBehaviour
{

    [SerializeField] private Animator animatorComponent;
    private int levelToLoad;

    

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animatorComponent.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

   
}
