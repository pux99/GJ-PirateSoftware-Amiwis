using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    [SerializeField]public TextMeshProUGUI Unidad;
    public TextMeshProUGUI Decena; 
    public TextMeshProUGUI Centena;
    public TextMeshProUGUI miles;
    public Image clockImage;
    int turns;
    int TotalTurns;
    int index=0;
    public List<Sprite> sprites=new List<Sprite>();


    // Start is called before the first frame update
    void Start()
    {
        TotalTurns = GameManager._turnCount;
    }

    // Update is called once per frame
    void Update()
    {
        turns=GameManager._turnCount;

        Unidad.text = (turns % 10).ToString();
        Decena.text = ((turns/10) % 10).ToString();
        Centena.text = ((turns / 100) % 10).ToString();
        miles.text = ((turns / 1000) % 10).ToString();
        if (turns<=TotalTurns-(TotalTurns/10)*(index+1))
        {
            if(index<sprites.Count-1)
                index++;
        }
        clockImage.sprite = sprites[index];

    }
}
