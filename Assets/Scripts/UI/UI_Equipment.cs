using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UI_Equipment : MonoBehaviour
{
    public TMP_Text nameLabel;
    public TMP_Text statLabels;
    public TMP_Text statValues;
    public UI_EquipmentSlot[] slots;

    private class CalculatedStat
    {
        public string id;
        public int baseValue;
        public int bonusValue;
    }
    
    public void Redraw(Hero hero)
    {
        if (!hero) return;
        nameLabel.text = hero.displayName;
        List<CalculatedStat> calc = new List<CalculatedStat>();
        foreach (Stat stat in hero.stats)
        {
            calc.Add(new CalculatedStat { baseValue = stat.value, bonusValue = 0, id = stat.id });
        }
        for (int i = 0; i < hero.equipment.items.Length; i++)
        {
            Item item = hero.equipment.items[i];
            slots[i].SetItem(item);
            if (item != null)
            {
                foreach (Stat stat in item.stats)
                {
                    var bonusValue = calc.Find(x => x.id == stat.id)?.bonusValue;
                    if (bonusValue != null)
                        calc.Find(x => x.id == stat.id).bonusValue += stat.value;
                }
            }
        }

        statLabels.text = "";
        statValues.text = "";
        for (int i = 0; i < hero.stats.Count; i++)
        {
            statLabels.text += hero.stats.ElementAt(i).id + "\n";
            CalculatedStat stat = calc.Find(x => x.id == hero.stats.ElementAt(i).id);
            statValues.text += $"{stat.baseValue} + {stat.bonusValue}\n";
        }
    }
}