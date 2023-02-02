using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public Player player;
    public TMP_Text descriptionText;
    public TMP_Text titleText;
    public TMP_Text goldText;

    public GameObject questWindow;

    public void OpenQuestWindow(Quest quest)
    {
        Debug.Log("OpenQuestWindow");
        Debug.Log(quest);
        Debug.Log(quest.title);

        this.quest = quest;
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        goldText.text = quest.gold.ToString();
    }

    public void AcceptQuest()
    {
        Debug.Log("AcceptQuest");
        questWindow.SetActive(false);
        player.quest = quest;
        quest.isActive = true; 
    }
}
