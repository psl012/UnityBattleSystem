using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState {PlayerTurn, EnemyTurn, Win, Lose}
public class BattleSystem : MonoBehaviour
{
    Player[] _players;
    Enemy[] _enemies;

    Character[] _characterOrder;

    public BattleState _battleState;

    void Awake()
    {
        _players = FindObjectsOfType<Player>();
        _enemies = FindObjectsOfType<Enemy>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Character[] Test = new Character[_players.Length];
        Test = MergeSort.charactermergeSort(_players, true, MergeSort.SortType.Speed);
        foreach(Character ch in Test){
            Debug.Log(ch._speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetBattleOrder()
    {

    }

    public void SelectTarget()
    {
        
    }



    
}
