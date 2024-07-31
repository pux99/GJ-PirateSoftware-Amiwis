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
    public GameObject portal; // Reference to the other GameObject


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

            if (portal != null)
            {
                Light2D portalLight = portal.GetComponent<Light2D>();
                if (portalLight != null)
                {
                    portalLight.enabled = true;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
