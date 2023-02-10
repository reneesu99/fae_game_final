using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public Player player;
    public UI_Manager uiManager;
    public Inventory_UI inventory;
    void Start()
    {
        player = GameManager.instance.player;
        uiManager = GameManager.instance.uiManager;
        
    }

    public void openSellPanel()
    {

        uiManager.ToggleInventory();
        inventory.Refresh();
        inventory.openSellSlots();
        
    }
}
