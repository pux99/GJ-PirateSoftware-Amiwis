using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static Interfaces;

public class Porta : MonoBehaviour, activable
{
    public LayerMask player;
    public Vector3 TeleportPosition;
    bool active;
    public Light2D ligth;
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
                collision.GetComponent<PlayerMovement>().pointToMove.position = TeleportPosition;
            }
        }
        
    }

}
