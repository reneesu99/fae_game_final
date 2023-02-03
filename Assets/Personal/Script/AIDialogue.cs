using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
public class AIDialogue: MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject inputPanel;

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

        StartCoroutine(Typing());

    }

    public void zeroText()
    {
        dialogueText.text = "";
        // index = 0;
        dialoguePanel.SetActive(false);
    }

    public void toggleInputTextPanel(bool state)
    {
        dialogueText.text = "";
        inputPanel.SetActive(state);
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
        if(index < dialogue.Count - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            toggleInputTextPanel(true);

        }
    }

    public async void Submit()
    {
        string playerInput = getInput();
        string chatGPTResponse = await getChatGPTResponse(playerInput);
        dialogue.Add(chatGPTResponse);
        toggleInputTextPanel(false); 
        NextLine();

        // takes player input gets API response, appends to dialogue and runs NextLine

    }



    public string getInput()
    {
        string text = inputPanel.GetComponent<TMP_InputField>().text;

        return text;
        // gets input from player and returns string
    }

    public Task<string> getChatGPTResponse(string input)
    {
        // gets chat response from ChatGPT API with input
        // returns reponse as string
        NetworkRequest network = new NetworkRequest();
        return network.TestPost(input);
    }
    


}