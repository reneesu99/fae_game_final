using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Money_UI : MonoBehaviour
{
    public TMP_Text moneyText;
    void Update()
    {
        moneyText.text = GameManager.instance.money.ToString();
    }
}
