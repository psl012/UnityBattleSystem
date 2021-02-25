using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState {PlayerTurn, EnemyTurn, Win, Lose}
public class BattleSystem : MonoBehaviour
{
    BattleEvents _battleEvents;
    Player[] _players;
    Enemy[] _enemies;
    Character[] _battleOrder;
    StateMachine _stateMachine;
    public BattleState _battleState;
    State_PlayerTurn _statePlayerTurn;
    State_EnemyTurn _stateEnemyTurn;
    State_Win _stateWin;
    State_Lose _stateLose;

    Character currentCharacter;
    int currentCharacterIndex = 0;

    void Awake()
    {
        _battleEvents = GetComponent<BattleEvents>();
        _players = FindObjectsOfType<Player>();
        _enemies = FindObjectsOfType<Enemy>();
        
        _battleOrder = SetBattleOrder(_players, _enemies, MergeSort.SortType.Speed); 

        _battleEvents.onEndTurn += NextCharacter;       
    }

    // Start is called before the first frame update
    void Start()
    {
       SetUpStateMachine();
    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.Tick();
    }

    Character[] SetBattleOrder(Player[] players, Enemy[] enemies, MergeSort.SortType sortType)
    {
        Character[] sortedPlayers = MergeSort.charactermergeSort(players, false, sortType);
        Character[] sortedEnemies = MergeSort.charactermergeSort(enemies, false, sortType);

        return MergeSort.charactermerge(sortedPlayers, sortedEnemies, false, sortType); 
    }

    public void SelectTarget()
    {
        
    }

    void SetUpStateMachine()
    {
        currentCharacter = _battleOrder[0];
        var _statePlayerTurn = new State_PlayerTurn(_battleEvents, currentCharacter);
        var _stateEnemyTurn = new State_EnemyTurn();
        var _stateWin = new State_Win();
        var _stateLose = new State_Lose();

        _stateMachine = new StateMachine();

        At(_statePlayerTurn, _stateEnemyTurn, IsEnemyTurn());
        At(_stateEnemyTurn, _statePlayerTurn, IsPlayerTurn());

        At(_statePlayerTurn, _stateLose, IsLose());
        At(_stateEnemyTurn, _stateLose, IsLose());
        
        At(_statePlayerTurn, _stateWin, IsWin());
        At(_stateEnemyTurn, _stateWin, IsWin());

        if (_battleOrder[0].tag == "Enemy")
        { 
            _stateMachine.SetState(_stateEnemyTurn);
        }
        else
        {
            _stateMachine.SetState(_statePlayerTurn);
        }

        void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
        Func<bool> IsPlayerTurn() => () => _battleState == BattleState.PlayerTurn;
        Func<bool> IsEnemyTurn() => () => _battleState == BattleState.EnemyTurn;
        Func<bool> IsWin() => () => _battleState == BattleState.Win;
        Func<bool> IsLose() => () => _battleState == BattleState.Lose;
    }

    void NextCharacter()
    {
        currentCharacterIndex += 1;
        currentCharacter = _battleOrder[currentCharacterIndex];

        if(currentCharacter.tag == "Player")
        {
            _battleState = BattleState.PlayerTurn;
        }
        else if (currentCharacter.tag == "Enemy")
        {
            _battleState = BattleState.EnemyTurn;
        }
    }

    void OnDestroy()
    {
        _battleEvents.onEndTurn -= NextCharacter;   
    }
    
}
