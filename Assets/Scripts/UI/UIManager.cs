using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public Button InventoryButton;
    [SerializeField] public GameObject menu;
    public GetGridPosition drawer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ImputActions();
    }

    void ImputActions()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            InventoryButton.onClick.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Escape)&&drawer.DrawingMod==GetGridPosition.Mod.NotDrawing)
        {
            if(menu.activeSelf)
                menu.SetActive(false);
            else menu.SetActive(true);
        }
    }
}
