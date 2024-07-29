using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public enum Direction { Left, Right, Up, Down }
    public Direction CurrentDirection;
    Direction NextDirection;
    [SerializeField] private float delay;
    float delayClock;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] public Transform pointToMove;
    [SerializeField] private LayerMask stopMovemet;
    [SerializeField] private Transform camera;
    [SerializeField] private GetAvarageColor avgColor;
    private bool tryingToMove = false;
    private bool moving=false;
    private bool CanMove=true;
    public bool canMove { get { return CanMove; } }
    public UnityEvent Moving=new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        pointToMove.parent=null;
        delayClock = delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove && moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointToMove.position, moveSpeed * Time.deltaTime);
        }
            
        if (delayClock>=0)
        {
            delayClock -= Time.deltaTime;
        }
        if (tryingToMove && delayClock < 0&& CanMove)
        {            
            if (CurrentDirection == NextDirection&& (Input.GetAxisRaw("Vertical")!=0|| Input.GetAxisRaw("Horizontal")!=0))
            {
                if (NextTileIsValid(pointToMove.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f)) && Input.GetAxisRaw("Vertical") == 0)
                {
                    pointToMove.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);                   
                    moving = true;
                }
                if (NextTileIsValid(pointToMove.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f)) && Input.GetAxisRaw("Horizontal") == 0)
                {
                    pointToMove.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    moving = true;
                }              
                if (moving)
                { Moving.Invoke(); }
            }
            Rotate(NextDirection);
            delayClock = delay;
            tryingToMove = false;
        }    
        if(Vector3.Distance(transform.position, pointToMove.position) <= 0.05f&&CanMove)
        {
            if(moving==true)
                delayClock = delay;
            moving = false;
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (Input.GetAxisRaw("Horizontal") == 1)
                    NextDirection = Direction.Right;
                else
                    NextDirection = Direction.Left;
                camera.transform.position = new Vector3(pointToMove.position.x+ Input.GetAxisRaw("Horizontal"), pointToMove.position.y, camera.position.z);
                tryingToMove = true;
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if(Input.GetAxisRaw("Vertical") == 1)
                    NextDirection = Direction.Up; 
                else
                    NextDirection = Direction.Down;
                camera.transform.position = new Vector3(pointToMove.position.x, pointToMove.position.y + Input.GetAxisRaw("Vertical"), camera.position.z);
                tryingToMove = true;
            }
        }    
    }
    bool NextTileIsValid(Vector3 position)
    {
        float ligth;
        ligth= avgColor.CheckLigthValue();
        Debug.Log("ligthLevel:"+ligth);
        if (!Physics2D.OverlapCircle(position, 0.3f, stopMovemet) && ligth <= 100)
            return true;
        else
         return false;
    }
    public void ToggleMovement(bool mode)
    {
        pointToMove.position = transform.position;
        CanMove = mode;
    }
    void Rotate(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            case Direction.Down:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break; 
            case Direction.Left:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case Direction.Right:
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
        }
        CurrentDirection = dir;
    }
}
