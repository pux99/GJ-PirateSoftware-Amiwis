using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class UICraftingManager : MonoBehaviour
{
    [SerializeField] private InventorySlot[] CraftingSlot = new InventorySlot[2];
    //[SerializeField] private InventorySlot ResaultImage;
    [SerializeField] private Potion potion;
    public GetGridPosition potiontrower;
    public UIInventoryManager inventory;
    private void Start()
    {
        SetResault();
    }
    public void AddToCrating(Herb herb)
    {
        for (int i = 0; i < CraftingSlot.Length;i++)
        {
            if (CraftingSlot[i].herb== null)
            {
                //CraftingSlot[i].herb = herb;
                CraftingSlot[i].SetSlot(herb);
                SetResault();
                //RefreshCrafting();
                return;
            }
        }
    }
    public void consumeHerbs()
    {
        foreach (InventorySlot slot in CraftingSlot)
        {
            for(int i = 0;i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].herb!=null && slot.herb!=null && slot.herb.gameObject == inventory.slots[i].herb.gameObject)
                {
                    inventory.slots[i].ClearSlot();
                    inventory.playerManager.inventory.ConsumeHerb(i);
                }
            }
            slot.ClearSlot();
            //Destroy(slot.herb.gameObject);
        }
        SetResault();
    }
    public void SetResault()
    {
        if (CraftingSlot[0].herb!=null && CraftingSlot[1].herb != null)
        {
            switch(CraftingSlot[0].herb.herbType)
            {
                case Herb.HerbType.Red:
                    switch (CraftingSlot[1].herb.herbType)
                    {
                        case Herb.HerbType.Red:
                            potion.SetSlot(Potion.PotionType.SmallLine);
                            break;
                        case Herb.HerbType.Blue:
                            potion.SetSlot(Potion.PotionType.Line);
                            break;
                        case Herb.HerbType.Green:
                            potion.SetSlot(Potion.PotionType.Circle);
                            break;
                    }
                    break;
                case Herb.HerbType.Blue:
                    switch (CraftingSlot[1].herb.herbType)
                    {
                        case Herb.HerbType.Red:
                            potion.SetSlot(Potion.PotionType.Line);
                            break;
                        case Herb.HerbType.Blue:
                            potion.SetSlot(Potion.PotionType.SmallCone);
                            break;
                        case Herb.HerbType.Green:
                            potion.SetSlot(Potion.PotionType.Cone);
                            break;
                    }
                    break;
                case Herb.HerbType.Green:
                    switch (CraftingSlot[1].herb.herbType)
                    {
                        case Herb.HerbType.Red:
                            potion.SetSlot(Potion.PotionType.Circle);
                            break;
                        case Herb.HerbType.Blue:
                            potion.SetSlot(Potion.PotionType.Cone);
                            break;
                        case Herb.HerbType.Green:
                            potion.SetSlot(Potion.PotionType.SmallCicle);
                            break;
                    }
                    break;


            }
        }
        else potion.ClearSlot();
    }

    public void throwing()
    {
        int size=1;
        GetGridPosition.Mod type= GetGridPosition.Mod.NotDrawing;
        switch (potion.Type)
        {
            case Potion.PotionType.Cone:
                type = GetGridPosition.Mod.DrawingCone;
                size = 2;
                break;
            case Potion.PotionType.Circle:
                type = GetGridPosition.Mod.DrawingCircle;
                size = 2;
                break;
            case Potion.PotionType.Line:
                type = GetGridPosition.Mod.DrawingLine;
                size = 5;
                break;
            case Potion.PotionType.SmallCicle:
                type = GetGridPosition.Mod.DrawingCircle;
                size = 1;
                break;
            case Potion.PotionType.SmallCone:
                type = GetGridPosition.Mod.DrawingCone;
                size = 1;
                break;
            case Potion.PotionType.SmallLine:
                type = GetGridPosition.Mod.DrawingLine;
                size = 3;
                break;
        }
        potiontrower.StartDrawing(type,size);
    }
}
