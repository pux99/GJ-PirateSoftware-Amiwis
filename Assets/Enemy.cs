using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.Properties;
using UnityEngine;
using static Interfaces;

public class Enemy : MonoBehaviour , EnemyActor
{
    public List<Vector3Int> MovementPoints = new List<Vector3Int>();
    public List<Vector3> Steps = new List<Vector3>();
    public int currentPoint;
    int NextPoint;
    Vector3 nextPos;
    Vector3 startingPos;
    public bool Test;
    public bool moving;

    void Start()
    {
        GameManager.actors.Add(this);
        startingPos =transform.position;
        if(MovementPoints!=null)
        Steps.Add(MovementPoints[0]);
        for(int i = 0; i < MovementPoints.Count; i++)
        {
            int next=i+1;
            if (i == MovementPoints.Count - 1)
                next = 0;
            Vector3Int Diference= MovementPoints[next]- MovementPoints[i];
            for(int j = 0; j < Mathf.Abs(Diference.x); j++)
            {
                Steps.Add(Steps.Last() + new Vector3Int((int)Mathf.Sign(Diference.x), 0));
            }
            for (int j = 0; j < Mathf.Abs(Diference.y); j++)
            {
                Steps.Add(Steps.Last() + new Vector3Int(0,(int)Mathf.Sign(Diference.y)));
            }
        }
        nextPos = startingPos;
        currentPoint = 0;
        Steps.Remove(MovementPoints[0]);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, nextPos, 5 * Time.deltaTime);
        if (Test)
        {
            Vector3 next=Steps.First();
            Steps.Remove(next);
            Steps.Add(next);
            nextPos = startingPos + next;
            moving = true;
            Test=false;
        }
    }
    public void MakeAction()
    {
        Test=true;
    }
    private void OnDrawGizmos()
    {
        for (int i = 0; i < MovementPoints.Count; i++)
        {
            Gizmos.color = UnityEngine.Color.red;
            Gizmos.DrawSphere(transform.position + MovementPoints[i], .5f);
            if (i < MovementPoints.Count-1)
                Gizmos.DrawLine(transform.position + MovementPoints[i] , transform.position + MovementPoints[i + 1]);
            else
                Gizmos.DrawLine(transform.position + MovementPoints[i], transform.position + MovementPoints[0]);
        }
    }
}
