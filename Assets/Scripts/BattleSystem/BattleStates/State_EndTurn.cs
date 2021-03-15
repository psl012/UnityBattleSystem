using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_EndTurn : IState
{
    BattleSystem _battleSystem;
    
    public State_EndTurn(BattleSystem battleSystem)
    {
        _battleSystem = battleSystem;
    }
    // Start is called before the first frame update
    public void Tick()
    {

    }

    public void OnEnter()
    {
        Debug.Log("hllo");
        NextCharacter();
    }

    public void OnExit()
    {
        
    }

    public void NextCharacter()
    {
        _battleSystem._currentCharacterIndex += 1;
        if(_battleSystem._currentCharacterIndex >= _battleSystem._battleOrder.Length)
        {
            _battleSystem._currentCharacterIndex = 0;
        }

        _battleSystem._currentCharacter = _battleSystem._battleOrder[_battleSystem._currentCharacterIndex];
        Debug.Log(_battleSystem._currentCharacter.name + "TURN");
        if(_battleSystem._currentCharacter.tag == "Player")
        {
            _battleSystem._battleState = BattleState.PlayerTurn;
        }
        
        else if (_battleSystem._currentCharacter.tag == "Enemy")
        {
            _battleSystem._battleState = BattleState.EnemyTurn;
        }
    }
}
