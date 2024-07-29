using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static Interfaces;

public class LuminousTile : MonoBehaviour, EnemyActor
{
    Light2D Light;
    public int TurnOnCounter;
    public int TurnOffCounter;
    public bool state;
    public int counter;
    public GameManager gameManager;

    public Sprite img_fungi0; // Assign Image A in the Unity Editor
    public Sprite img_fungi1; // Assign Image B in the Unity Editor

    private SpriteRenderer spriteRenderer;
    private bool isfungi0 = true;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.actors.Add(this);
        Light = GetComponent<Light2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on this GameObject.");
        }
    }

    private void changeImage()
    {
        if (isfungi0)
        {
            spriteRenderer.sprite = img_fungi1;
        }
        else
        {
            spriteRenderer.sprite = img_fungi0;
        }
        isfungi0 = !isfungi0;
    }
    public void MakeAction()
    {
        counter--;
        if (counter <= 0)
        {
            if (state)
            {                
                state = false;
                counter = TurnOnCounter;
                Light.intensity = 0;
                changeImage();
            }
            else
            {
                state = true;
                counter = TurnOffCounter;
                Light.intensity = 1;
                changeImage();
            }
        }
    }
}
