using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Conversation
{
    // public Dialogue[] conversation;
    // public Dialogue[] giveQuest;
    // public Dialogue[] finishQuest;
    public string[] before;
    public string[] during;
    public string[] after;

    public Quest quest;
}