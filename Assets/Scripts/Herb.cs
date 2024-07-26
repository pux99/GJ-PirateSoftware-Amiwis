using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herb : MonoBehaviour
{
    public enum HerbType { Red,Blue,Green}
    public HerbType herbType;
    private SpriteRenderer sprite;
    private Collider2D col;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }
    public void TurnOff()
    {
        sprite.enabled = false;
        col.enabled = false;
    }
    public void TurnOn()
    {
        sprite.enabled = true;
        col.enabled = true;
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
