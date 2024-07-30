using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public Button InventoryButton;
    [SerializeField] public GameObject menu;
    public GetGridPosition drawer;
    public GameObject EndOfGameScrean;
    public GameObject Win;
    public TextMeshProUGUI WinText;
    public GameObject Loss;
    public TextMeshProUGUI LossText;
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
    public void EndOfGame(bool Wining,string coment)
    {
        EndOfGameScrean.SetActive(true);
        Time.timeScale= 0;
        if (Wining)
        {
            Win.SetActive(true);
            Loss.SetActive(false);
            WinText.text = coment;
        }
        else
        {
            Loss.SetActive(true);
            Win.SetActive(false);
            LossText.text = coment;
        }
    }
}
