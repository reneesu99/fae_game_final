using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public bool cat;

    public Conversation[] conversations;
    public TMP_Text dialogueText;
    public GameObject contButton;
    public QuestGiver questGiver;
    public Player player;
    // public WebRequestAsyncOperation response;
    public List<string> dialogue;
    public Dialogue dialogueManager;
    // public AIDialogue AIDialogueManager;

    private int index;
    private Quest quest;

    public float wordSpeed;
    public bool playerIsClose;
    public UnityWebRequest Request;


    void Update()
    {
        // TODO: helper method for updating conversations
        // TODO: use dictionary to store conversations 
        if(conversations[0].quest.isActive)
        {
            //TODO: if appropriate items are selected in toolbar, then quest is completed
            // if(GameManager.instance.toolbarUI.selectedItem == conversations[0].quest.goal.item && GameManager.instance.toolbarUI.selectedItemAmount >= conversations[0].quest.goal.requiredAmount)
            if(conversations[0].quest.goal.IsReached())
            {
                dialogue = conversations[0].after;
                player.gold += conversations[0].quest.gold;
                quest = null;

            }
            else
            {
                dialogue = conversations[0].during;
                quest = null;
            }
        }
        else
        {

            dialogue = conversations[0].before;
            quest = conversations[0].quest;

        }
        if(Input.GetKeyDown(KeyCode.F) && playerIsClose)
        {
            dialoguePanel.SetActive(true);
            if(cat)
            {
                dialogueManager.New(new List<string>() {"Hi Renee! What's up?"}, null, true);
            }
            else
            {
                dialogueManager.New(dialogue, quest);
            }

        }

    }



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
