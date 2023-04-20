#nullable enable
using System;

public class Equipment
{
    public Item[] items;
    public Equipment()
    {
        items = new Item[Enum.GetNames(typeof(ItemType)).Length];
    }
    
    public Item? AddItem(Item item)
    {
        int slotNumber = (int)item.type;
        Item previouslyEquippedItem = items[slotNumber]; 
        items[slotNumber] = item;
        return previouslyEquippedItem;
    }

    public Item? RemoveItem(ItemType itemType)
    {
        return RemoveItem((int)itemType);
    }

    public Item? RemoveItem(int slotNumber)
    {
        Item previouslyEquippedItem = items[slotNumber]; 
        items.SetValue(null, slotNumber);
        return previouslyEquippedItem;
    }
}