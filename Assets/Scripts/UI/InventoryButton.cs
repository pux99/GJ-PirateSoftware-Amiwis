using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] private Button inventoryButton;
    [SerializeField] private GameObject inventory;
    [SerializeField] private int pickDistance;
    [SerializeField] private int fullDistance;
    [SerializeField] private float openOrCloseSpeed;
    [SerializeField] private float peakSpeed;
    private float CurrentSpeed;
    private Vector3 buttonStartingPosition;
    private Vector3 InventoryStartingPosition;
    private Vector3 pointToMove;
    private bool ChangePosition;
    private bool expand;
    private bool openInventory; 
    private bool inventoryAction;
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        buttonStartingPosition = transform.position;
        InventoryStartingPosition= inventory.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangePosition)
        {
            transform.position =Vector3.MoveTowards(transform.position, pointToMove, CurrentSpeed * Time.deltaTime);
            if(expand)
            {
                inventory.transform.position -= new Vector3(CurrentSpeed * Time.deltaTime, 0);
            }
            else
                inventory.transform.position += new Vector3 (CurrentSpeed * Time.deltaTime,0);
            if (Vector3.Distance(transform.position, pointToMove) <= 0.05)
            {
                ChangePosition = false;
                if (!openInventory)
                    inventoryAction = false;
                if (!expand)
                {
                    inventory.transform.position = InventoryStartingPosition;
                }
            }
        }    
    }
    public void HoverIn()
    {
        if (!inventoryAction)
        {
            pointToMove = buttonStartingPosition - new Vector3(pickDistance, 0, 0);
            ChangePosition = true;
            expand = true;
            CurrentSpeed = peakSpeed;
        }
    }
    public void HoverOut()
    {
        if(!inventoryAction)
        {
            pointToMove = buttonStartingPosition;
            ChangePosition = true;
            expand = false;
            CurrentSpeed = peakSpeed;
        }
        
    }
    public void OpenOrCloseInventory()
    {
        openInventory= !openInventory;
        expand = openInventory;
        inventoryAction = true;
        if (openInventory)
        {
            pointToMove = buttonStartingPosition - new Vector3(fullDistance, 0, 0);
            gameManager.StopTime(false);
            EventSystem.current.sendNavigationEvents = true;
        }
        else
        {
            pointToMove = buttonStartingPosition;
            gameManager.StopTime(true);
            EventSystem.current.sendNavigationEvents = false;
        }    
        ChangePosition = true;
        CurrentSpeed = openOrCloseSpeed;
    }
}
