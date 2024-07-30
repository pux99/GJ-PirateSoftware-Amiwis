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
    public Sprite conoChico;
    public Sprite conoGrande;
    public Sprite circuloChico;
    public Sprite circulo;
    public Sprite lineaChica;
    public Sprite linea;

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
                slotImage.sprite = linea;
                break;
            case PotionType.SmallLine:
                slotImage.sprite = lineaChica;
                break;
            case PotionType.Circle:
                slotImage.sprite = circulo;
                break;
            case PotionType.SmallCicle:
                slotImage.sprite = circuloChico;
                break;
            case PotionType.Cone:
                slotImage.sprite = conoGrande;
                break;
            case PotionType.SmallCone:
                slotImage.sprite = conoChico;
                break;
        }
    }
}
