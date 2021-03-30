using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState {PlayerTurn, EnemyTurn, EndTurn, Win, Lose}
public class BattleSystem : MonoBehaviour
{
    public event Action onPlayerTurn = delegate{};
    public event Action onEnemyTurn = delegate{};
    public event Action onTargetMode = delegate{};
    public event Action onEndTurn = delegate{};

    public BattleState _battleState{get; set;}
    public Character[] _battleOrder{get; private set;}
    public Character _currentCharacter{get; set;}
    public int _currentCharacterIndex{get; set;} = 0;
    public UIPanelChanger[] _characterUIPanels{get; private set;}
    public CharacterPanelManager _characterPanelManager { get; set; }

    StateMachine _stateMachine;
    BattleField _battleField;
    public BattlePlacement[] _battlePlacementOrder;
    BattleEnterer _battleEnterer;

    State_PlayerTurn _statePlayerTurn;
    State_EnemyTurn _stateEnemyTurn;
    State_Win _stateWin;
    State_Lose _stateLose;
    State_EndTurn _stateEndTurn;

    void Awake()
    { 
        _battleField = FindObjectOfType<BattleField>();
        _battleEnterer = FindObjectOfType<BattleEnterer>();
        _battleEnterer.Initialize();

        _characterPanelManager = GetComponent<CharacterPanelManager>();
        _characterPanelManager.InitializeCharacterPanels();
        
        _characterUIPanels = GetComponentsInChildren<UIPanelChanger>();
        _battleOrder = FindObjectsOfType<Character>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _battleOrder = MergeSort.charactermergeSort(_battleOrder, false, MergeSort.SortType.Speed);

        _battlePlacementOrder = new BattlePlacement[_battleOrder.Length];

        for(int i = 0; i < _battleOrder.Length; i++)
        {
            _battlePlacementOrder[i] = _battleOrder[i].GetComponentInParent<BattlePlacement>();
        }

        SetUpStateMachine();
    }

    // Update is called once per frame
    void Update()
    {
        _stateMachine.Tick();
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


        At(_statePlayerTurn, _stateWin, IsWin());
        At(_stateEnemyTurn, _stateWin, IsWin());
        At(_stateEndTurn, _stateWin, IsWin());

        At(_statePlayerTurn, _stateLose, IsLose());
        At(_stateEnemyTurn, _stateLose, IsLose());
        At(_stateEndTurn, _stateLose, IsLose());

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
        _characterUIPanels[_currentCharacter._battlePosition].ActivateTargetPanel();
        onTargetMode();
    }

    public void ResetTargets()
    {
        _characterPanelManager.ResetCharacterPanelTargets();
    }
 
    public bool IsBattleOver()
    {
        // Check Number of Players
        int numberOfAlivePlayers = 0;
        int numberOfAliveEnemies = 0;

        foreach(BattlePlacement playerBattlePlacement in _battleField._playerBattlePlacement)
        {
            if(playerBattlePlacement._isOccupied && !playerBattlePlacement._mycharacterBattler._isDead)
            {
                numberOfAlivePlayers += 1;
            }
        }

        foreach(BattlePlacement enemyBattlePlacement in _battleField._enemyBattlePlacement)
        {
            if(enemyBattlePlacement._isOccupied && !enemyBattlePlacement._mycharacterBattler._isDead)
            {
                numberOfAliveEnemies += 1;
            }
        }
        
        if(numberOfAlivePlayers <= 0)
        {
            _battleState = BattleState.Lose;
            return true;
        }

        else if (numberOfAliveEnemies <= 0)
        {
            _battleState = BattleState.Win;
            return true;
        }
        else
        {
            return false;
        }

    }
}
