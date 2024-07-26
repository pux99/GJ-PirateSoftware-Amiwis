using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryManager : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private UICraftingManager craftingManager;
    [SerializeField] private InventorySlot[] slots = new InventorySlot[6];
    void Start()
    {
        foreach (var slot in slots)
        {
            slot.AddHerbToCrafting.AddListener(SendToCrafting);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RefreshInentory();
    }
    public void RefreshInentory()
    {
        Herb[] Herbs = new Herb[6];
        Herbs = playerManager.GetInventory();
        for (int i = 0; i < slots.Length; i++)
        {
            if (Herbs[i] != null)
            {
                slots[i].herb = Herbs[i];
                slots[i].slotImage.enabled = true;
                slots[i].slotImage.sprite = Herbs[i].getSprite();
                slots[i].slotImage.color = Herbs[i].getColor();
            }
            else slots[i].slotImage.enabled = false;
        }
    }
    void SendToCrafting(Herb herb)
    {
        craftingManager.AddToCrating(herb);
    }
}
