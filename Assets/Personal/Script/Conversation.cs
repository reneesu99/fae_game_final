using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Conversation
{
    // public Dialogue[] conversation;
    // public Dialogue[] giveQuest;
    // public Dialogue[] finishQuest;
    public List<string> before;
    public List<string> during;
    public List<string> after;

    public Quest quest;
}