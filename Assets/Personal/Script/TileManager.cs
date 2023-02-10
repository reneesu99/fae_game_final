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
        TileBase tile = interactableMap.GetTile(position);
        Debug.Log(tile.name);
        if(tile.name == "Summer_Plowed")
        {
            cropMap.SetTile(position, plantedTile);
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
