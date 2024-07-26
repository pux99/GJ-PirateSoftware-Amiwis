using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Interfaces;

public class GameManager : MonoBehaviour
{
    private int _turnCount;
    public int turnCount {  get { return _turnCount; } }
    public PlayerManager _playerManager;
    public static List<EnemyActor> actors= new List<EnemyActor>();
    // Start is called before the first frame update
    void Start()
    {
        _playerManager.PlayerMove.AddListener(NextTurn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextTurn()
    {
        _turnCount++;
        Debug.Log(turnCount);
        foreach (EnemyActor actor in actors)
        {
            actor.MakeAction();
        }
    }
}
