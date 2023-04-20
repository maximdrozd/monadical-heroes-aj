using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

[Serializable]
public class Item : INullable
{
    public string id;
    public string displayName;
    public ItemType type;
    public ItemRarity rarity;
    public Sprite uiSprite;
    public Sprite worldSprite;
    public List<Stat> stats;
    public override string ToString()
    {
        return $"{id}-{displayName}";
    }

    public bool IsNull => string.IsNullOrWhiteSpace(id);
}

public enum ItemType
{
    Helm,
    Armour,
    Boots,
    Shield,
    MainHand,
    Offhand
}

public enum ItemRarity
{
    Common, //grey
    Uncommon, //green
    Rare, //blue
    Epic, //purple
    Legendary //gold-brown
}