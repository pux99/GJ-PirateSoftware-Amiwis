using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropingHebs : MonoBehaviour, IPointerClickHandler
{
    public InventorySlot slot;
    public Transform player;
    public Transform hebsHolder;
    public UICraftingManager craftmanager;
    public Inventory inventory;
    public Button button;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)) 
        {
            GameObject sel = EventSystem.current.currentSelectedGameObject;
            if (button.gameObject == sel&&button.interactable)
            {
                if (slot.herb != null)
                {
                    Debug.Log(slot.herb);
                    slot.herb.gameObject.transform.parent = hebsHolder;
                    slot.herb.gameObject.transform.position = player.position;
                    foreach (InventorySlot slot2 in craftmanager.CraftingSlot)
                        if (slot2.herb != null && slot2.herb.gameObject == slot.herb.gameObject)
                        {
                            slot2.ClearSlot();
                            craftmanager.SetResault();
                        }
                    slot.herb.TurnOn();
                    for (int i = 0; i < inventory.herbs.Length; i++)
                    {
                        if (inventory.herbs[i] != null && inventory.herbs[i].gameObject == slot.herb.gameObject)
                            inventory.herbs[i] = null;
                    }
                    slot.ClearSlot();
                }
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button==PointerEventData.InputButton.Right&&button.interactable)
        {
            if(slot.herb!=null)
            {
                Debug.Log(slot.herb);
                slot.herb.gameObject.transform.parent=hebsHolder;
                slot.herb.gameObject.transform.position = player.position;
                foreach (InventorySlot slot2 in craftmanager.CraftingSlot)
                    if (slot2.herb != null && slot2.herb.gameObject == slot.herb.gameObject)
                    {
                        slot2.ClearSlot();
                        craftmanager.SetResault();
                    }
                slot.herb.TurnOn();
                for (int i = 0; i < inventory.herbs.Length; i++)
                {
                    if (inventory.herbs[i] != null && inventory.herbs[i].gameObject==slot.herb.gameObject)
                        inventory.herbs[i]=null;
                }
                slot.ClearSlot();             
            }
        }
    }
}
