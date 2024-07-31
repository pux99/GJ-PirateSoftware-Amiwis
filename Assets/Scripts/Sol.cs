using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Interfaces;

public class Sol : MonoBehaviour, EnemyActor
{
    public int stepbetewinMovments;
    public int counter;
    public UIManager manager;
    private Vector3 originalPos;
    void Start()
    {
        originalPos = transform.position;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerManager>()!=null)
        {
            Debug.Log("player GameOver");
            manager.EndOfGame(false, "Burn by the sun");
        }
        if (collision.GetComponent<Herb>() != null&& collision.GetComponent<Herb>().herbType==Herb.HerbType.Key)
        {
            Debug.Log("key GameOver");
            manager.EndOfGame(false, "Portal Gem destroy by the sun");
        }
    }

    public void BackToStart()
    {
        transform.position = originalPos;
    }
}
