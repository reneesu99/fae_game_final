// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class AIDialogue: MonoBehaviour
// {
//     public GameObject dialoguePanel;

//     public TMP_Text dialogueText;
//     public QuestGiver questGiver;
//     public float wordSpeed;

//     public GameObject contButton;


//     private Quest quest;
    

//     public List<string> dialogue;
//     private int index;


//     public void New(string[] dialogueGiven, Quest questGiven = null)
//     {
//         dialogue = dialogueGiven;

//         StartCoroutine(Typing());

//     }

//     public void zeroText()
//     {
//         dialogueText.text = "";
//         index = 0;
//         dialoguePanel.SetActive(false);
//     }

//     IEnumerator Typing()
//     {
//         foreach(char letter in dialogue[index].ToCharArray())
//         {
//             dialogueText.text+= letter;
//             yield return new WaitForSeconds(wordSpeed);
//         }
//     }

//     public void NextLine()
//     {
//         if(index < dialogue.Length - 1)
//         {
//             index++;
//             dialogueText.text = "";
//             StartCoroutine(Typing());
//         }
//         else
//         {
//             // TODO: switch out zero text to display an input window

//             zeroText();

//         }
//     }

//     public void Submit()
//     {
//         string playerInput = getInput();
//         string chatGPTResponse = getChatGPTResponse(playerInput);
//         dialogue.Add(chatGPTResponse);
//         NextLine();



//         // takes player input gets API response, appends to dialogue and runs NextLine

//     }



//     public void getInput()
//     {
//         pass;
//         // gets input from player and returns string
//     }

//     public void getChatGPTResponse(string input)
//     {
//         // gets chat response from ChatGPT API with input
//         // returns reponse as string
//         pass;
//     }
    


// }