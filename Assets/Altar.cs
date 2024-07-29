using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    public Inventory inventory;
    public int NumberOfKeys;
    public GameObject toActivate;
    public Interfaces.activable active;
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
            Debug.Log("active");
            toActivate.GetComponent<Interfaces.activable>().Activate();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
