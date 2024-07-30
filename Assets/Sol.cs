using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Interfaces;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Sol : MonoBehaviour, EnemyActor
{
    public int stepbetewinMovments;
    public int counter;
    void Start()
    {
        GameManager.actors.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void move()
    {
        transform.position-=new Vector3(1,0,0);
    }
    public void MakeAction()
    {
        counter--;
        if (counter <= 0)
        {
            move();
            counter = stepbetewinMovments;
        }
    }
}
