using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class UICraftingManager : MonoBehaviour
{
    private Herb[] cratingHerb=new Herb[2];
    [SerializeField] private InventorySlot[] CraftingSlot = new InventorySlot[2];
    //[SerializeField] private InventorySlot ResaultImage;
    [SerializeField] private Potion potion;
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
    //public void RefreshCrafting()
    //{
    //    for (int i = 0; i < CraftingSlot.Length; i++)
    //    {
    //        if (cratingHerb[i] != null)
    //        {
    //            CraftingSlot[i].slotImage.enabled = true;
    //            CraftingSlot[i].slotImage.sprite = cratingHerb[i].getSprite();
    //            CraftingSlot[i].slotImage.color = cratingHerb[i].getColor();
    //        }
    //        else CraftingSlot[i].slotImage.enabled = false;
    //    }
    //}
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
}
