using System;
using System.Collections;
using System.Collections.Generic;
using Systems;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public delegate void OnEquip(Item item);
    public OnEquip onEquip;
    
    public Item item;
    public Image icon;
    public Image background;

    public void SetItem(Item contextItem)
    {
        item = contextItem;
        icon.sprite = contextItem.uiSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onEquip?.Invoke(item);
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
