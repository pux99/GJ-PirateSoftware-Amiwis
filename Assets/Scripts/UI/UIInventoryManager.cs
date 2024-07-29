using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryManager : MonoBehaviour
{
    [SerializeField] public PlayerManager playerManager;
    [SerializeField] private UICraftingManager craftingManager;
    [SerializeField] public InventorySlot[] slots = new InventorySlot[4];
    [SerializeField] public InventorySlot[] Keyslots = new InventorySlot[2];
    public UIManager uimanager;
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
        Herb[] Herbs = new Herb[4];
        Herbs = playerManager.GetInventory();
        Herb[] Keys = new Herb[2];
        Keys = playerManager.GetInventoryKeys();
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
        for (int i = 0; i < Keyslots.Length; i++)
        {
            if (Keys[i] != null)
            {
                Keyslots[i].herb = Keys[i];
                Keyslots[i].slotImage.enabled = true;
                Keyslots[i].slotImage.sprite = Keys[i].getSprite();
                Keyslots[i].slotImage.color = Keys[i].getColor();
            }
            else Keyslots[i].slotImage.enabled = false;
        }
    }
    void SendToCrafting(Herb herb)
    {
        craftingManager.AddToCrating(herb);
    }
}
