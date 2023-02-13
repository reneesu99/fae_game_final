using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public Player player;
    public UI_Manager uiManager;
    public Inventory_UI inventory_ui;
    public Inventory inventory;
    public GameObject storePanel;
    void Start()
    {
        player = GameManager.instance.player;
        uiManager = GameManager.instance.uiManager;
        
    }

    public void openSellPanel()
    {

        uiManager.ToggleInventory();
        inventory_ui.Refresh();
        inventory_ui.openSellSlots();
        
    }
    public void openBuyPanel()
    {
        storePanel.SetActive(true);
        
    }
    // public void buyCarrotSeeds()
    // {
        // subtract money
        // add carrot seeds to inventory
    // }
    // public void buyStrawberrySeeds()
    // {
    //     storePanel.SetActive(true);
        
    // }
    // public void buyWatermelonSeeds()
    // {
    //     storePanel.SetActive(true);
        
    // }

}
