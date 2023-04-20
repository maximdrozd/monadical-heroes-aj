using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Library", menuName = "GameData/Inventory/ItemLibrary", order = 1)]
public class ItemLibrary : ScriptableObject
{
    public List<Item> items;

    public Item GetRandomItem()
    {
        int index = Random.Range(0, items.Count);
        return items.ElementAt(index);
    }
}
