using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Slot_UI : MonoBehaviour
{
    public Image itemIcon;
    public int slotID;
    public int price;
    public Inventory inventory;
    public string name;


    public TextMeshProUGUI quanitityText;
    [SerializeField] private GameObject highlight;
    [SerializeField] public GameObject sellOverlay;


    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            name = slot.itemName;
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1,1,1,1);
            quanitityText.text = slot.count.ToString();
            price = slot.price;
        }
    }



    public void SetEmpty()
    {
        name = null;
        itemIcon.sprite = null;
        itemIcon.color = new Color(1,1,1,0);
        quanitityText.text = "";
        price = 0;

    }

    public void Sell()
    {
        GameManager.instance.money += price;
        Debug.Log("slotID " + slotID);
        inventory.Remove(slotID);
    }
    

    public void SetHighlight(bool value)
    {
        highlight.SetActive(value);
    }
    public void ToggleSell(bool value)
    {
        sellOverlay.SetActive(value);
    }

}
