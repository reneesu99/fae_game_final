using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public List<Slot_UI> slots = new List<Slot_UI>();
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
        
    }
    public void ToggleInventory()
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            Refresh();
            
        }

    void Refresh()
    {
        for(int i = 0; i < slots.Count; i++)
        {
            // Debug.Log(slots.Count);
            if(player.inventory.slots[i].itemName !="")
            {
                slots[i].SetItem(player.inventory.slots[i]);
            }
            else
            {
                // Debug.Log(i);
                slots[i].SetEmpty();
            }
        }
    }

    public void Remove(int slotIndex)
    {
        Item itemToDrop = GameManager.instance.itemManager.GetItemByName(
            player.inventory.slots[slotIndex].itemName);
        if(itemToDrop != null)
        {
            player.DropItem(itemToDrop);
            player.inventory.Remove(slotIndex);
            Refresh();
        }
    }
}
