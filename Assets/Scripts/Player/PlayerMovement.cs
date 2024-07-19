using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Transform pointToMove;
    
    [SerializeField] private LayerMask stopMovemet;
    [SerializeField] private Transform camera;
    [SerializeField] private GetAvarageColor avgColor;
    private bool tryingToMove = false;
    // Start is called before the first frame update
    void Start()
    {
        pointToMove.parent=null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointToMove.position, moveSpeed * Time.deltaTime);
        if (tryingToMove)
        {
            if (NextTileIsValid(pointToMove.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f)))
            {
                pointToMove.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
            if (NextTileIsValid(pointToMove.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f))&& Input.GetAxisRaw("Horizontal")==0)
            {
                pointToMove.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
            tryingToMove = false;
        }    
        if(Vector3.Distance(transform.position, pointToMove.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                camera.transform.position = new Vector3(pointToMove.position.x+ Input.GetAxisRaw("Horizontal"), pointToMove.position.y, camera.position.z);
                //if (NextTileIsValid(pointToMove.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f)) && test)
                //{ 
                //    pointToMove.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f); 
                //    test = false;
                //}
                tryingToMove = true;
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                camera.transform.position = new Vector3(pointToMove.position.x, pointToMove.position.y + Input.GetAxisRaw("Vertical"), camera.position.z);
                //if (NextTileIsValid(pointToMove.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f)))
                //    pointToMove.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                tryingToMove = true;
            }
        }    
    }
    bool NextTileIsValid(Vector3 position)
    {
        //camera.transform.position =new Vector3( position.x,position.y,camera.position.z);
        float ligth;
        ligth= avgColor.CheckLigthValue();
        Debug.Log("ligthLevel:"+ligth);
        if (!Physics2D.OverlapCircle(position, 0.3f, stopMovemet) && ligth <= 100)
            return true;
        else
            return false;
    }
}
