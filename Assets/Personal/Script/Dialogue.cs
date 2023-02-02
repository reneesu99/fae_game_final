using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue: MonoBehaviour
{
    public GameObject dialoguePanel;

    public TMP_Text dialogueText;
    public QuestGiver questGiver;
    public float wordSpeed;

    public GameObject contButton;


    private Quest quest;
    

    public List<string> dialogue;
    private int index;


    public void New(List<string> dialogueGiven, Quest questGiven = null)
    {
        dialogue = dialogueGiven;

        if(questGiven != null)
        {
            quest = questGiven;

        }
        StartCoroutine(Typing());

    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text+= letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        // contButton.SetActive(false);
        if(index < dialogue.Count - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {

            zeroText();
            Debug.Log(quest);


            if(quest != null)
            {
                questGiver.OpenQuestWindow(quest);
            }
            quest = null;



        }
    }


}