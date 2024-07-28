using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Herb : MonoBehaviour
{
    public enum HerbType { Red,Blue,Green}
    public HerbType herbType;
    private SpriteRenderer sprite;
    private Collider2D col;
    private Light2D light;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        light = GetComponent<Light2D>();
    }
    public void TurnOff()
    {
        sprite.enabled = false;
        col.enabled = false;
        light.enabled = false;
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
