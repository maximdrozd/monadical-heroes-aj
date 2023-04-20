using System;
using System.Collections.Generic;

[Serializable]
public class Inventory
{
    public List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }
    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
