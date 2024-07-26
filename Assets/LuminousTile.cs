using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static Interfaces;

public class LuminousTile : MonoBehaviour, EnemyActor
{
    Light2D Light;
    public int TurnOnCounter;
    public int TurnOffCounter;
    public bool state;
    public int counter;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.actors.Add(this);
        Light = GetComponent<Light2D>();
    }
    public void MakeAction()
    {
        counter--;
        if (counter <= 0)
        {
            if (state)
            {
                state = false;
                counter = TurnOnCounter;
                Light.intensity = 0;
            }
            else
            {
                state = true;
                counter = TurnOffCounter;
                Light.intensity = 1;
            }
        }
    }
}
