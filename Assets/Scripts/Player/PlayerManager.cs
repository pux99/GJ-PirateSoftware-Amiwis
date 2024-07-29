using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public PlayerMovement playerMovement;
    [SerializeField] public Inventory inventory;
    public UnityEvent PlayerMove=new UnityEvent();
    [SerializeField] private SpriteRenderer spriteRenderer;
    public int InventorySlots = 2;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement.Moving.AddListener(playerMoving);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ToggleMovement(bool Mode)
    {
        playerMovement.ToggleMovement(Mode);
    }
    public Herb[] GetInventory()
    {
        return inventory.herbs;
    }
    public Herb[] GetInventoryKeys()
    {
        return inventory.Keys;
    }
    void playerMoving()
    {
        PlayerMove.Invoke();
    }
}
