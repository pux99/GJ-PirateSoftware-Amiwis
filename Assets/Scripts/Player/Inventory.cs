using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    [SerializeField] public Herb[] herbs =new Herb[6];
    [SerializeField] private LayerMask PickUps;
    [SerializeField] private float couldown;
    public float couldownTimer;
    // Start is called before the first frame update

    public CameraShake cameraShake;
    public float shakeIntensity = 5f;
    public float shakeDuration = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&couldownTimer < 0)
        {
            GrabHerb(transform.position);
            couldownTimer = couldown;
        }
        if(couldownTimer > 0) 
        {
            couldownTimer-=Time.deltaTime;
        }
    }
    public void DiscardHerb(int index)
    {
        if (index>=0&&index<herbs.Length)
        {
            herbs[index] = null;
        }
    }
    public void ConsumeHerb(int index)
    {
        if (index >= 0 && index < herbs.Length)
        {
            herbs[index] = null;
        }
    }
    public void GrabHerb(Vector3 position)
    {
        if (CheckIfInventoryIsFull())
        {
            Collider2D hitColiders = Physics2D.OverlapCircle(position, 0.3f, PickUps);
            if (Physics2D.OverlapCircle(position, 0.3f, PickUps))
            {
                if (hitColiders.gameObject.GetComponent<Herb>() != null)
                {
                    for (int i = 0;i<herbs.Length;i++)
                    {
                        if (herbs[i] == null)
                        {
                            herbs[i] = hitColiders.gameObject.GetComponent<Herb>();
                            hitColiders.transform.parent = gameObject.transform;
                            herbs[i].TurnOff();
                            cameraShake.ShakeCamera(shakeIntensity, shakeDuration);
                            break;
                        }
                    }
                }

            }
        }
    }
    public bool CheckIfInventoryIsFull()
    {
        foreach (var herb in herbs)
        {
            if(herb==null)
            {
                return true;
            }
        }
        return false;
    }
}
