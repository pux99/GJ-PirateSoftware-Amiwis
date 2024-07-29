using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    [SerializeField] public Herb[] herbs = new Herb[4];
    [SerializeField] public Herb[] Keys = new Herb[2];
    [SerializeField] private LayerMask PickUps;
    [SerializeField] private LayerMask interactables;
    [SerializeField] private float couldown;
    public float couldownTimer;
    public PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && couldownTimer < 0 && playerManager.playerMovement.canMove)
        {
            GrabHerb(transform.position);
            Interact(playerManager.playerMovement.CurrentDirection);
            couldownTimer = couldown;
        }
        if (couldownTimer > 0)
        {
            couldownTimer -= Time.deltaTime;
        }
    }
    public void DiscardHerb(int index)
    {
        if (index >= 0 && index < herbs.Length)
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
    public void Interact(PlayerMovement.Direction direction)
    {
        Vector3 pos=new Vector3(0,0,0);
        switch (direction)
        {
            case PlayerMovement.Direction.Up:
                pos = transform.position + new Vector3(0, 1);
                break;
            case PlayerMovement.Direction.Down:
                pos = transform.position + new Vector3(0, -1);
                break;
            case PlayerMovement.Direction.Left:
                pos = transform.position + new Vector3(-1, 0);
                break;
            case PlayerMovement.Direction.Right:
                pos = transform.position + new Vector3(1, 0);
                break;
        }
        Collider2D hitColiders = Physics2D.OverlapCircle(pos, 0.3f, interactables);
        if (hitColiders!=null)
        {
            Debug.Log("altar");
            if (hitColiders.gameObject.GetComponent<Altar>() != null)
            {
                Debug.Log("altar");
                hitColiders.gameObject.GetComponent<Altar>().Activate();
            }
        }
    }
    public void GrabHerb(Vector3 position)
    {
        Collider2D hitColiders = Physics2D.OverlapCircle(position, 0.3f, PickUps);
        if (Physics2D.OverlapCircle(position, 0.3f, PickUps))
        {
            if (hitColiders.gameObject.GetComponent<Herb>() != null)
            {
                switch (hitColiders.gameObject.GetComponent<Herb>().herbType)
                {
                    case Herb.HerbType.Expancion:
                        playerManager.InventorySlots++;
                        Destroy(hitColiders.gameObject);
                        break;
                    case Herb.HerbType.Key:
                        for (int i = 0; i < Keys.Length; i++)
                        {
                            if (Keys[i] == null)
                            {
                                Keys[i] = hitColiders.gameObject.GetComponent<Herb>();
                                hitColiders.transform.parent = gameObject.transform;
                                Keys[i].TurnOff();
                                break;
                            }
                        }
                        break;
                    default:
                        if (CheckIfInventoryIsFull())
                        {
                            for (int i = 0; i < herbs.Length; i++)
                            {
                                if (herbs[i] == null)
                                {
                                    herbs[i] = hitColiders.gameObject.GetComponent<Herb>();
                                    hitColiders.transform.parent = gameObject.transform;
                                    herbs[i].TurnOff();
                                    break;
                                }
                            }
                        }
                        break;
                }

            }

        }
    }
    public bool CheckIfInventoryIsFull()
    {
        for (int i = 0; i < playerManager.InventorySlots; i++)
        {
            if (herbs[i] == null)
            {
                return true;
            }
        }
        //foreach (var herb in herbs)
        //{
        //    if(herb==null)
        //    {
        //        return true;
        //    }
        //}
        return false;
    }
}
