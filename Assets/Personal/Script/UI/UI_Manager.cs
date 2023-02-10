using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public List<Inventory_UI> inventoryUIs;
    public Dictionary<string, Inventory_UI> inventoryUIByName = new Dictionary<string, Inventory_UI>();
    public static Slot_UI draggedSlot;
    public static Image draggedIcon;
    public GameObject inventoryPanel;
    public Inventory_UI GetInventory_UI(string inventoryName)
    {
        if(inventoryUIByName.ContainsKey(inventoryName))
        {
            return inventoryUIByName[inventoryName];
        }
        Debug.LogWarning("No inventory UI with name: " + inventoryName);
        return null;

    }

    public void Awake()
    {
        Initialize();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }

    }
    public void ToggleInventory()
    {
        if(inventoryPanel!=null)
        {

            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            // Debug.Log(inventoryUIs);
            // Debug.Log(inventoryUIs[0].inventoryName);
            // Debug.Log(inventoryUIs[1].inventoryName);


            RefreshAll();
        }
    }

    public void RefreshInventoryUI(string inventoryName)
    {
        Debug.Log(inventoryUIByName[inventoryName]);

        if(inventoryUIByName.ContainsKey(inventoryName))
        {
            inventoryUIByName[inventoryName].Refresh();
            Debug.Log(inventoryUIByName[inventoryName]);
        }
    }
    public void RefreshAll()
    {
        foreach(KeyValuePair<string, Inventory_UI> keyValuePair in inventoryUIByName)
        {
            Debug.Log(keyValuePair.Value);
            Debug.Log(keyValuePair.Key);

            keyValuePair.Value.Refresh();
        }
    }


    void Initialize()
    {
        foreach(Inventory_UI ui in inventoryUIs)
        {
            if(!inventoryUIByName.ContainsKey(ui.inventoryName))
            {
                inventoryUIByName.Add(ui.inventoryName, ui);
                Debug.Log(ui.inventoryName);
            }
        }
    }
}
