using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ItemManager itemManager;
    public int curDay;
    public int money;    
    public int cropInventory;

    public CropData selectedCropToPlant;
    public event UnityAction onNewDay;
    public TileManager tileManager;
    public UI_Manager uiManager;
    public Player player;
    public float startTime;

    private void Awake()
    {
        startTime = Time.time;
        curDay = 0;
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        itemManager = GetComponent<ItemManager>();
        tileManager = GetComponent<TileManager>();
        uiManager = GetComponent<UI_Manager>();
        player = FindObjectOfType<Player>();

    }

    private void Update()
    {


        var newDay = (int)Math.Floor((Time.time - startTime)/10);
        if(newDay > curDay)
        {
            curDay = newDay;
            Debug.Log("New Day");
        }

    }
    // void OnEnable ()
    // {
    //     Crop.onPlantCrop += OnPlantCrop;
    //     Crop.onHarvestCrop += OnHarvestCrop;
    // }
    // void OnDisable ()
    // {
    //     Crop.onPlantCrop -= OnPlantCrop;
    //     Crop.onHarvestCrop -= OnHarvestCrop;
    // }
    // // Called when a crop has been planted.
    // // Listening to the Crop.onPlantCrop event.
    // public void OnPlantCrop (CropData cop)
    // {
    //     cropInventory--;

    // }
    // // Called when a crop has been harvested.
    // // Listening to the Crop.onCropHarvest event.
    // public void OnHarvestCrop (CropData crop)
    // {
    //     money += crop.sellPrice;

    // }
//     // Called when we want to purchase a crop.
//     public void PurchaseCrop (CropData crop)
//     {
//     }
//     // Do we have enough crops to plant?
//     public bool CanPlantCrop ()
//     {
//     }
//     // Called when the buy crop button is pressed.
//     public void OnBuyCropButton (CropData crop)
//     {
//     }
}
