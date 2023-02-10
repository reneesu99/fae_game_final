using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tilemap cropMap;

    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile tilledTile;
    [SerializeField] private Tile plantedTile;
    [SerializeField] private Tile crop1Tile;
    [SerializeField] private Tile crop2Tile;
    [SerializeField] private Tile crop3Tile;
    [SerializeField] private Tile crop4Tile;
    [SerializeField] private Tile crop5Tile;
    [SerializeField] public Player player;
    [SerializeField] public Item carrot;
    [SerializeField] public Toolbar_UI toolbarUI;
    // [SerializeField] public Dictionary<string, Item> CropTileDict = new Dictionary<string, Item>();





    void Start()
    {
        foreach(var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);
            if(tile!= null && tile.name == "Interactable_Visible")
            {
                interactableMap.SetTile(position, hiddenInteractableTile);
            }
        }
    }
    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);
        if(tile!= null)
        {
            if(tile.name == "Interactable" || tile.name == "Summer_Plowed")
            {
                return true;
            }
        }
        return false;

    }

    public void SetInteracted(Vector3Int position)
    {
        TileBase cropTile = cropMap.GetTile(position);
        TileBase groundTile = interactableMap.GetTile(position);

        // Debug.Log(tile.name);
        if(groundTile.name == "Summer_Plowed")
        {
            if(!cropTile && toolbarUI.selectedSlot.name == "Carrot Seeds")
            {
                cropMap.SetTile(position, plantedTile);
                player.inventory.GetInventoryByName("Toolbar").Remove(toolbarUI.selectedSlot.slotID);
            }
            else if(cropTile.name == "crops_5")
            {
                player.inventory.Add("Backpack", carrot);
                cropMap.SetTile(position, null);
            }
        }
        else
        {
            interactableMap.SetTile(position, tilledTile);
        }

    }

    public void growCrops()
    {
        foreach(var position in cropMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = cropMap.GetTile(position);
            if(tile!= null)

            {
                if(tile.name == "crops_0")
                {
                    cropMap.SetTile(position, crop1Tile);
                }
                else if(tile.name == "crops_1")
                {
                    cropMap.SetTile(position, crop2Tile);
                }
                else if(tile.name == "crops_2")
                {
                    cropMap.SetTile(position, crop3Tile);
                }
                else if(tile.name == "crops_3")
                {
                    cropMap.SetTile(position, crop4Tile);
                }
                else if(tile.name == "crops_4")
                {
                    cropMap.SetTile(position, crop5Tile);
                }
            }
        }
    }

    // public void SetPlanted(Vector3Int position)
    // {
    //     interactableMap.SetTile(position, farmedTile); 

    // }

}
