using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public enum PotionType
    {
        non,
        Line,
        SmallLine,
        Circle,
        SmallCicle,
        Cone,
        SmallCone
    }
    public PotionType Type;
    public Image slotImage;

    public void SetSlot(PotionType PType)
    {
        Type = PType;
        SetColot();
        slotImage.enabled = true;
    }
    public void ClearSlot()
    {
        slotImage.enabled = false;
    }
    void SetColot()
    {
        switch (Type)
        {
            case PotionType.Line:
                slotImage.color = new Color32(21, 41, 61,255);
                break;
            case PotionType.SmallLine:
                slotImage.color = new Color32(61, 41, 21,255);
                break;
            case PotionType.Circle:
                slotImage.color = new Color32(255, 0, 64,255);
                break;
            case PotionType.SmallCicle:
                slotImage.color = new Color32(255, 0, 32, 255);
                break;
            case PotionType.Cone:
                slotImage.color = new Color32(0, 128, 20, 255);
                break;
            case PotionType.SmallCone:
                slotImage.color = new Color32(0, 64, 20, 255);
                break;
        }
    }
}
