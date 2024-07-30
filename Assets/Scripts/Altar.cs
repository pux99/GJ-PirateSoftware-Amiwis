using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    public Inventory inventory;
    public int NumberOfKeys;
    public GameObject toActivate;
    public Interfaces.activable active;

    public Sprite newSprite; // The new sprite you want to change to

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
