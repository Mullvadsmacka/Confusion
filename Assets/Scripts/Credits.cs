using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour
{

    [SerializeField] private GameObject musicObject;
    // Start is called before the first frame update
    void Start()
    {
      musicObject = GameObject.Find("MusicObject");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonClick()
    {
        //Vet att man borde g�ra med singleton pattern eller n�got men jag hinner inte s� det blir nasty kod ist�llet
        Destroy(musicObject);
        SceneManager.LoadScene(0);

    }

}
