using Systems;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    public GameObject pfItemSlot;
    public GameObject content;
    public void Redraw(Inventory inventory)
    {
        for (int i = content.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < inventory.items.Count; i++)
        {
            GameObject slot = Instantiate(pfItemSlot, content.transform);
            UI_ItemSlot uiItem = slot.GetComponent<UI_ItemSlot>(); 
            uiItem.SetItem(inventory.items[i]);
            uiItem.onEquip += item =>
            {
                ItemSystem.Instance.EquipItem(item);
                UISystem.Instance.RedrawEquipment();
            };
        }
    }
}
