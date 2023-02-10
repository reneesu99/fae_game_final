using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public string itemName;
        public int count;
        public int maxAllowed;
        public Sprite icon;

        public Slot()
        {
            itemName = "";
            count = 0;
            maxAllowed = 99;
        }

        public bool IsEmpty
        {
            get
            {
                if(itemName == "" && count == 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool CanAddItem(string itemName)
        {
            if(this.itemName ==itemName)
            {
                return true;
            }
            return false;
        }
        public void AddItem(string itemName, Sprite icon)
        {
            this.itemName = itemName;
            this.icon = icon;
            count ++;
        
        }
        public void RemoveItem()
        {
            if(count == 1)
            {
                itemName = "";
                icon = null;
                count = 0;
            }
            else
            {
                count--;
            }
        }
    }   
    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)
    {
        for(int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }
    public void Add(Item item)
    {

        // if (item.type == quest.goal.type)
        // {
        //     Debug.Log("goal")
        //     quest.goal.currentAmount ++;
        // }
        foreach(Slot slot in slots)
        {
            if(slot.itemName== item.data.itemName)
            {
                slot.icon = item.data.icon;
                slot.count++;
                return;
            }
        }
        foreach(Slot slot in slots)
        {
            if(slot.itemName == "")
            {
                slot.icon = item.data.icon;
                slot.itemName= item.data.itemName;
                slot.count = 1;
                return;
            }
        }
        
    }


    public void Remove(int index)
    {
        Slot slot = slots[index];
        if(slot.count > 0)
        {
            slot.count--;
            if(slot.count == 0)
            {
                slot.icon = null;
                slot.itemName= "";
            }
        }
    }

    public void MoveSlot(int fromIndex, int toIndex, Inventory toInventory)
    {
        Slot fromSlot = slots[fromIndex];
        Slot toSlot = toInventory.slots[toIndex];
        if(toSlot.IsEmpty || toSlot.CanAddItem(fromSlot.itemName))
        {
            toSlot.AddItem(fromSlot.itemName, fromSlot.icon);
            fromSlot.RemoveItem();
        }
    }
    
}

