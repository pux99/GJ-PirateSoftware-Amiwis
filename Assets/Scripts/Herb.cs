using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Herb : MonoBehaviour
{
    public enum HerbType { Red,Blue,Green,Key,Expancion}
    public HerbType herbType;
    private SpriteRenderer sprite;
    private Collider2D col;
    public bool TurnOfAligth=false;
    public Light2D light2d;
    public Light2D Selflight2d;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        Selflight2d = GetComponent<Light2D>(); 
    }
    public void TurnOff()
    {
        sprite.enabled = false;
        col.enabled = false;
        if (TurnOfAligth)
        {
            if(light2d != null)
                light2d.enabled = false;
        }
        Selflight2d.enabled = false;
    }
    public void TurnOn()
    {
        sprite.enabled = true;
        col.enabled = true;
        Selflight2d.enabled=true;
    }
    public Sprite getSprite()
    {
        return sprite.sprite;
    }
    public Color getColor()
    {
        return sprite.color;
    }
}
