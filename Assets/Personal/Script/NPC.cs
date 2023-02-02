using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;

    public Conversation[] conversations;
    public TMP_Text dialogueText;
    public GameObject contButton;
    public QuestGiver questGiver;
    public Player player;
    // public WebRequestAsyncOperation response;
    private string[] dialogue;
    public Dialogue dialogueManager;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;
    public UnityWebRequest Request;


    void Update()
    {
        if(conversations[0].quest.isActive)
        {

            if(conversations[0].quest.goal.IsReached())
            {
                dialogue = conversations[0].after;
                player.gold += conversations[0].quest.gold;

            }
            else
            {
                // Debug.Log(player.gold);
                // Debug.Log(conversations[0].quest.gold);
                dialogue = conversations[0].during;
            }
        }
        else
        {
            // Debug.Log(conversations[0].before[0]);

            dialogue = conversations[0].before;
            // Debug.Log(conversations[0].quest.title);

        }
        if(Input.GetKeyDown(KeyCode.F) && playerIsClose)
        {
                dialoguePanel.SetActive(true);
                // Debug.Log(conversations[0].quest.title);
                dialogueManager.New(dialogue, conversations[0].quest);
        }
        // if(dialogueText.text == dialogue[index])
        // {
        //     contButton.SetActive(true);
        // }
    }


    // public void zeroText()
    // {
    //     dialogueText.text = "";
    //     index = 0;
    //     dialoguePanel.SetActive(false);
    // }

    // IEnumerator Typing()
    // {
    //     foreach(char letter in dialogue[index].ToCharArray())
    //     {
    //         dialogueText.text+= letter;
    //         yield return new WaitForSeconds(wordSpeed);
    //     }
    // }

    // public void NextLine()
    // {
    //     contButton.SetActive(false);
    //     if(index < dialogue.Length - 1)
    //     {
    //         index++;
    //         dialogueText.text = "";
    //         StartCoroutine(Typing());
    //     }
    //     else
    //     {
    //         zeroText();
    //         Debug.Log(conversations[0].before[0]);
    //         Debug.Log(conversations[0].quest.title);
    //         questGiver.OpenQuestWindow(conversations[0].quest);

    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
        private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;

        }
    }
    

}
