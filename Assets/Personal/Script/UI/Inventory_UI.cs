using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public string inventoryName;
    // public Player player;
    public List<Slot_UI> slots = new List<Slot_UI>();
    [SerializeField] public Canvas canvas;
    // private Slot_UI draggedSlot;
    // private Image draggedIcon;

    private Inventory inventory;
    // Update is called once per frame

    // private void Awake()
    // {
    //     canvas = FindObjectOfType<Canvas>();
    // }

    private void Start()
    {
        inventory = GameManager.instance.player.inventory.GetInventoryByName(inventoryName);
        SetupSlots();
        Refresh();
    } 



    public void Refresh()
    {
        if(slots.Count == inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                // Debug.Log(slots.Count);
                if(inventory.slots[i].itemName !="")
                {
                    Debug.Log("refresh" + inventory.slots[i]);
                    slots[i].SetItem(inventory.slots[i]);
                }
                else
                {
                    // Debug.Log(i);
                    slots[i].SetEmpty();
                }
            }

        }
        // else if (slots.Count == player.toolbar.slots.Count)
        // {
        //     for(int i = 0; i < slots.Count; i++)
        //     {
        //         // Debug.Log(slots.Count);
        //         if(player.toolbar.slots[i].itemName !="")
        //         {
        //             slots[i].SetItem(player.inventory.slots[i]);
        //         }
        //         else
        //         {
        //             // Debug.Log(i);
        //             slots[i].SetEmpty();
        //         }
        //     }

        // }
        
    }


    public void openSellSlots()
    {
        if(slots.Count == inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                // enable function to sell slot
                
                slots[i].ToggleSell(true);
                
            }

        }
        
    }
    public void Remove()
    {
        Item itemToDrop = GameManager.instance.itemManager.GetItemByName(
            inventory.slots[UI_Manager.draggedSlot.slotID].itemName);
        if(itemToDrop != null)
        {
            GameManager.instance.player.DropItem(itemToDrop);
            inventory.Remove(UI_Manager.draggedSlot.slotID);
            Refresh();
        }
        UI_Manager.draggedSlot = null;
    }

    public void SlotBeginDrag(Slot_UI slot)
    {
        UI_Manager.draggedSlot = slot;
        UI_Manager.draggedIcon = Instantiate(UI_Manager.draggedSlot.itemIcon);
        UI_Manager.draggedIcon.transform.SetParent(canvas.transform);
        UI_Manager.draggedIcon.raycastTarget = false;
        // draggedIcon.rectTransform.sizeDelta  = new Vector2(50,50);
        MoveToMousePosition(UI_Manager.draggedIcon.gameObject);
        // Debug.Log("Begin Drag: "+ UI_ManagerdraggedSlot.name);

    }

    public void SlotDrag()
    {
        MoveToMousePosition(UI_Manager.draggedIcon.gameObject);
        // Debug.Log("Drag: "+ draggedSlot.name);
    }

    public void SlotEndDrag()
    {
        Destroy(UI_Manager.draggedIcon.gameObject);
        UI_Manager.draggedIcon = null;
        // Debug.Log("End Drag: "+ draggedSlot.name);
        // if(slot != draggedSlot)
        // {
        //     player.inventory.Swap(draggedSlot.slotIndex, slot.slotIndex);
        //     Refresh();
        // }
    }

    public void SlotDrop(Slot_UI slot)
    {
        UI_Manager.draggedSlot.inventory.MoveSlot(UI_Manager.draggedSlot.slotID, slot.slotID, slot.inventory);
        GameManager.instance.uiManager.RefreshAll();
        // Debug.Log("Drop: "+ draggedSlot.name + "on " + slot.name);
        // if(slot != draggedSlot)
        // {
        //     player.inventory.Swap(draggedSlot.slotIndex, slot.slotIndex);
        //     Refresh();
        // }
    }

    private void MoveToMousePosition(GameObject toMove)
    {
        if(canvas != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
            toMove.transform.position = canvas.transform.TransformPoint(position);
            Debug.Log("position: " + position);
        }
    }
    void SetupSlots()
    {
        int counter = 0;
        foreach(Slot_UI slot in slots)
        {
            slot.slotID = counter;
            counter++;
            slot.inventory = inventory;
        }
    }
}
