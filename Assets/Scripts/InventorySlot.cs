using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image slotImage;
    public Herb herb;
    public UnityEvent<Herb> AddHerbToCrafting=new UnityEvent<Herb>();
    [SerializeField]bool added;

    public void addHerb()
    {
        if(herb != null&&!added)
        {
            AddHerbToCrafting.Invoke(herb);
            added = true;
        }
    }
    public void SetSlot(Herb Nherb)
    {
        herb = Nherb;
        slotImage.sprite = herb.getSprite();
        slotImage.color = herb.getColor();
        slotImage.enabled = true;
    }
    public void OutOfCrafting()
    {
        added = false;
    }
    public void ClearSlot()
    {
        slotImage.sprite=null;
        slotImage.enabled=false;
        herb=null;
        added = false;
    }
}
