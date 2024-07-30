using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Interfaces;

public class GameManager : MonoBehaviour
{
    public int TotalTurns;
    public static int _turnCount=10;
    public int turnCount {  get { return _turnCount; } }
    [SerializeField]public PlayerManager _playerManager;
    public static List<EnemyActor> actors= new List<EnemyActor>();
    
    // Start is called before the first frame update
    void Start()
    {
        _playerManager.PlayerMove.AddListener(NextTurn);
        _turnCount = TotalTurns;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextTurn()
    {
        _turnCount--;
        foreach (EnemyActor actor in actors)
        {
            actor.MakeAction();
        }
    }
    public  void StopTime(bool b)
    {
        _playerManager.ToggleMovement(b);
    }
}
