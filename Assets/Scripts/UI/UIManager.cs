using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button InventoryButton;
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
    }
}
