using Systems;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_EquipmentSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public Image icon;
    public Image background;

    public void SetItem(Item contextItem)
    {
        item = contextItem;
        if (item != null) icon.sprite = item.uiSprite;
        background.gameObject.SetActive(item == null);
        icon.gameObject.SetActive(item != null);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null) ItemSystem.Instance.RemoveItem(item);
        UISystem.Instance.HideTooltip();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        UISystem.Instance.ShowTooltip(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UISystem.Instance.HideTooltip();
    }
}
