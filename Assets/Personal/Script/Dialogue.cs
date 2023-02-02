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
    

    public string[] dialogue;
    private int index;


    public void New(string[] dialogueGiven, Quest questGiven = null)
    {
        dialogue = dialogueGiven;

        if(questGiven != null)
        {
            quest = questGiven;

        }
        StartCoroutine(Typing());

    }

    // public void Update()
    // {
    //     if(dialogueText.text == dialogue[index])
    //     {
    //         contButton.SetActive(true);
    //     }
    // }
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
        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            Debug.Log(quest.title);

            zeroText();
            // Debug.Log(conversations[0].before[0]);
            // Debug.Log(conversations[0].quest.title);
            if(quest != null)
            {
                questGiver.OpenQuestWindow(quest);
            }

        }
    }


}