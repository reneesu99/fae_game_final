using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public CollectibleType type;
    public Sprite icon;
}

public enum CollectibleType
{
    NONE, APPLE
}

