using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Collectible[] collectibleItems;
    private Dictionary<CollectibleType, Collectible> collectibleItemsDict = new Dictionary<CollectibleType, Collectible>();

    private void Awake()
    {
        foreach(Collectible item in collectibleItems)
        {
            AddItem(item);
        }
    }
    private void AddItem(Collectible item)
    {
        if(!collectibleItemsDict.ContainsKey(item.type))
        {
            collectibleItemsDict.Add(item.type, item);

        }
    }

    public Collectible GetItemByType(CollectibleType type)
    {
        if(collectibleItemsDict.ContainsKey(type))
        {
            return collectibleItemsDict[type];
        }

        return null;

    }

}
