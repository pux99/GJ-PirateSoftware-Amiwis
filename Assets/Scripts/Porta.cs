using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static Interfaces;

public class Porta : MonoBehaviour, activable
{
    public Vector3 TeleportPosition;
    bool active;
    public Light2D ligth;
    public bool victory;
    public UIManager manager;
    public Sol sun;
    public bool tutorial;
    public GameManager gameManager;
    public UITimer timer;

    // Start is called before the first frame update
    public void Activate()
    {
        active = true;
        ligth.intensity = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == 7&& active)//7 es la layer player
        {
            collision.transform.position = TeleportPosition;
            if(collision.GetComponent<PlayerMovement>() != null) 
            {
                if (tutorial)
                {
                    sun.BackToStart();
                    GameManager._turnCount = 2500;
                    gameManager.TotalTurns = 2500;
                    timer.TotalTurns = 2500;
                }
                if(!victory)
                    collision.GetComponent<PlayerMovement>().pointToMove.position = TeleportPosition;
                else
                {
                    manager.EndOfGame(true, "Congratulation Blobli got home safe");
                }
            }
        }
        
    }

}
