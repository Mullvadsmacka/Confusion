using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevalChanger : MonoBehaviour
{

    [SerializeField] private Animator animatorComponent;
    private int levelToLoad;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
   
            FadeToLevel(1);
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animatorComponent.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

   
}
