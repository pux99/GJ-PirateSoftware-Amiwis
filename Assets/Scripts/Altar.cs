using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Altar : MonoBehaviour
{
    public Inventory inventory;
    public int NumberOfKeys;
    public GameObject toActivate;
    public Interfaces.activable active;

    public Sprite newSprite; // The new sprite you want to change to
    public Light2D light2D; // Reference to the Light 2D component


    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (light2D != null)
        {
            light2D.enabled = false;
        }
    }

    public bool TryToActivate()
    {
        bool AllKeys=true;
        for (int i = 0; i < NumberOfKeys; i++)
        {
            if (inventory.Keys[i] == null)
            {
                AllKeys = false;
            }
        }
        return AllKeys;
    }
    public void Activate()
    {
        if (TryToActivate())
        {
            for (int i = 0;i < inventory.Keys.Length;i++)
            {
                inventory.Keys[i] = null;
            }
            toActivate.GetComponent<Interfaces.activable>().Activate();
            spriteRenderer.sprite = newSprite;
            if (light2D != null)
            {
                light2D.enabled = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
