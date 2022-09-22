using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{


    [SerializeField] private GameObject closedMouth;
    [SerializeField] private GameObject openMouth;

    [SerializeField] private TMP_Text textComponent;
    [SerializeField] private string questText;
    [SerializeField] private string questCompleteText;
    [SerializeField] private int amountToCollect = 1;
    [SerializeField] private GameObject questGiverText;

    private Animator animator;

    [SerializeField] private float transitionTime;
    private float timer;
    private bool openingEyes;

    //  [SerializeField] private GameObject doorToOpenWhenQuestIsComplete;

    void Start()
    {

        //closedMouth.SetActive(true);
        //openMouth.SetActive(false);

        questGiverText.SetActive(false);

        textComponent.text = questText;
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Sleep", true);
    }


    void Update()
    {


        if (openingEyes == true)
        {   
            Debug.Log("StartTimer");

            timer += Time.deltaTime;
            if (timer >= transitionTime)
            {

                Morph();

                openingEyes = false;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            questGiverText.SetActive(true);
            if (/*collision.GetComponent<PlayerState>().coins >= amountToCollect*/PlayerState.coins >= amountToCollect)
            {
                /* textComponent.text = questCompleteText; 
                 collision.GetComponent<Quest>().isQuestComplete = true;
                 doorToOpenWhenQuestIsComplete.SetActive(false);
                 Debug.Log("Öppna");
                 */

                openingEyes = true;
                animator.SetBool("Eyes", true);
                animator.SetBool("Sleep", false);
                animator.SetBool("Awake", false);

            }
            else
            {
                animator.SetBool("Sleep", false);
                animator.SetBool("Awake", true);

                textComponent.text = questText;
            }


        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            if (openingEyes == true)
            {

            }
            else
            {
                animator.SetBool("Sleep", true);
                animator.SetBool("Awake", false);

                questGiverText.SetActive(false);
            }

        }
    }


    private void Morph()
    {
        questGiverText.SetActive(false);
        animator.SetBool("Monster", true);
        Debug.Log("nu ska den ändras");
        closedMouth.SetActive(false);
        openMouth.SetActive(true);
    }

}
