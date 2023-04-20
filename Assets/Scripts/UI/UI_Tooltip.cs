using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Tooltip : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _rarity;
    [SerializeField] private TMP_Text _type;
    [SerializeField] private TMP_Text _stats;
    [SerializeField] private Canvas _canvas;
    
    public void SetItem(Item item)
    {
        if (item != null)
        {
            _title.text = item.displayName;
            _rarity.text = item.rarity.ToString();
            _type.text = item.type.ToString();
            _stats.text = "";
            foreach (Stat stat in item.stats)
            {
                _stats.text += $"{stat.id}\t{stat.value}\n";
            }
        }
    }
    
    void Update()
    {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvas.transform as RectTransform,
            Input.mousePosition, _canvas.worldCamera,
            out movePos);

        transform.position = _canvas.transform.TransformPoint(movePos + Vector2.left * 15);
    }
}
