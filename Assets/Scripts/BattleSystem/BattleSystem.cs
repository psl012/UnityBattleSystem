using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState {PlayerTurn, EnemyTurn, EndTurn, Win, Lose}
public class BattleSystem : MonoBehaviour
{
  //  BattleEvents _battleEvents;
    public event Action onPlayerTurn = delegate{};
    public event Action onEnemyTurn = delegate{};
    public event Action onTargetMode = delegate{};
    public event Action onEndTurn = delegate{};

    Player[] _players;
    Enemy[] _enemies;
    public Character[] _battleOrder{get; private set;}
    StateMachine _stateMachine;
    public BattleState _battleState;
    State_PlayerTurn _statePlayerTurn;
    State_EnemyTurn _stateEnemyTurn;
    State_Win _stateWin;
    State_Lose _stateLose;
    State_EndTurn _stateEndTurn;
    //TargetIcon _targetIcon;
    public Character _currentCharacter{get; set;}
    public int _currentCharacterIndex{get; set;} = 0;
    public UIPanelChanger[] _characterUIPanels{get; private set;}

    BattleAI[] _battleAI;
    

    void Awake()
    {
        _players = FindObjectsOfType<Player>();

        _enemies = FindObjectsOfType<Enemy>();   
        _battleAI = FindObjectsOfType<BattleAI>();

      //  _targetIcon = GetComponentInChildren<TargetIcon>();
        _characterUIPanels = GetComponentsInChildren<UIPanelChanger>();

    }

    // Start is called before the first frame update
    void Start()
    {
      /**  _battleOrder = SetBattleOrder(_players, _enemies, MergeSort.SortType.Speed);   

        Character[] test1 = FindObjectsOfType<Character>();
        test1 = MergeSort.charactermergeSort(test1, false, MergeSort.SortType.Speed);*/
        _battleOrder = FindObjectsOfType<Character>();
        _battleOrder = MergeSort.charactermergeSort(_battleOrder, false, MergeSort.SortType.Speed);

        Debug.Log(_battleOrder.Length);
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

    void SetUpStateMachine()
    {
        _currentCharacter = _battleOrder[0];
        var _statePlayerTurn = new State_PlayerTurn(this, _currentCharacter);
        var _stateEnemyTurn = new State_EnemyTurn(this);
        var _stateEndTurn = new State_EndTurn(this);
        var _stateWin = new State_Win();
        var _stateLose = new State_Lose();


        _stateMachine = new StateMachine();

        At(_statePlayerTurn, _stateEndTurn, IsEndTurn());
        At(_stateEnemyTurn, _stateEndTurn, IsEndTurn());

        At(_stateEndTurn, _statePlayerTurn, IsPlayerTurn());
        At(_stateEndTurn, _stateEnemyTurn, IsEnemyTurn());

        At(_statePlayerTurn, _stateLose, IsLose());
        At(_stateEnemyTurn, _stateLose, IsLose());
        
        At(_statePlayerTurn, _stateWin, IsWin());
        At(_stateEnemyTurn, _stateWin, IsWin());

        Debug.Log(_battleOrder[0].name + "TURN");

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
        Func<bool> IsEndTurn() => () => _battleState == BattleState.EndTurn;
    }

    public void PlayerTurn()
    {
        onPlayerTurn();
    }

    public void EnemyTurn()
    {
        onEnemyTurn();
    }

    public void EndTurn()
    {
        _battleState = BattleState.EndTurn;
        onEndTurn();
    }

    public void TargetMode()
    {
        _characterUIPanels[0].ActivateTargetPanel();
        onTargetMode();
    }

    void OnDestroy()
    {

    }
    
}
