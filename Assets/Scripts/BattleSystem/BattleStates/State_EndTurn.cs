﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_EndTurn : IState
{
    BattleSystem _battleSystem;
    
    bool _hasCalledNextCharacter = false;

    public State_EndTurn(BattleSystem battleSystem)
    {
        _battleSystem = battleSystem;
    }
    // Start is called before the first frame update
    public void Tick()
    {
        if(_battleSystem._numOfEnemyKilledThisTurn > 0)
        {
            Debug.Log("Work on the death animation Pual");
            return;
        }

        else if (!_hasCalledNextCharacter)
        { 
            _hasCalledNextCharacter = true;
            if(_battleSystem.IsBattleOver()) return;
            NextCharacter();
        }
        else
        {
            Debug.LogWarning("A condition has been caught fix this");
            return;
        }
    }

    public void OnEnter()
    {
        _hasCalledNextCharacter = false;
    }

    public void OnExit()
    {
        
    }

    public void NextCharacter()
    {
        _battleSystem._currentCharacterIndex += 1;
        
        bool IsBattlePlacementEmpty()
        {
            Debug.Log(_battleSystem._currentCharacterIndex + "error below");
            if (_battleSystem._battlePlacementOrder[_battleSystem._currentCharacterIndex]._isOccupied)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        bool IsCharacterIndexOverflow()
        {
            if(_battleSystem._currentCharacterIndex >= _battleSystem._battleOrder.Length)
            {
                return true;
            }
            else
            {
                return false;   
            }
        }


        if(IsCharacterIndexOverflow())
        {
            _battleSystem._currentCharacterIndex = 0;
        }

        int infiniteLoopDef = 0;
        while(IsBattlePlacementEmpty() && !IsCharacterIndexOverflow())
        {
            infiniteLoopDef += 1;
            _battleSystem._currentCharacterIndex += 1;

            if(infiniteLoopDef >= 100) 
            {
                Debug.LogWarning("Potential Infinite Loop Found!");
                break;
            }
        }

        if(IsCharacterIndexOverflow())
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
