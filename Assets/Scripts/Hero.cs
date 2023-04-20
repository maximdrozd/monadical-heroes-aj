using System;
using System.Collections.Generic;
using Systems;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public GameObject ragdoll;
    public string id;
    public string displayName;
    public List<Stat> stats;
    public Equipment equipment;
    public SpriteRenderer indicator;

    private void Awake()
    {
        equipment = new Equipment();
    }

    private void OnMouseDown()
    {
        HeroSystem.Instance.SetActiveHero(this);
        UISystem.Instance.RedrawEquipment();
    }

    public void SetActive(bool isActive)
    {
        indicator.color = isActive ? Color.green : Color.clear;
    }
}
