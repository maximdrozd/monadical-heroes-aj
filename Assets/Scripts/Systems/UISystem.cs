using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Systems
{
    public class UISystem : MonoBehaviour
    {
        public static UISystem Instance;
        public UI_Inventory inventory;
        public UI_Equipment equipment;
        public UI_Tooltip tooltip;

        private void Awake()
        {
            Instance = this;
        }

        public void RedrawInventory()
        {
            inventory.Redraw(ItemSystem.Instance.inventory);
        }

        public void RedrawEquipment()
        {
            equipment.gameObject.SetActive(true);
            equipment.Redraw(HeroSystem.Instance.activeHero);
        }

        public void ShowTooltip(Item item)
        {
            if (item != null)
            {
                tooltip.SetItem(item);
                tooltip.gameObject.SetActive(true);
            }
        }

        public void HideTooltip()
        {
            tooltip.gameObject.SetActive(false);
        }
    }
}

