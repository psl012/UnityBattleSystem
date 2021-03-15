﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_EnemyTurn : IState
{
    BattleSystem _battleSystem;
    Character _allies;
    Character _enemies;
    public State_EnemyTurn(BattleSystem battleSystem)
    {
        _battleSystem = battleSystem;
    }

    // Start is called before the first frame update
    public void Tick()
    {

    }

    public void OnEnter()
    {
        Debug.Log("dfdf");
        _battleSystem.EnemyTurn();
        _battleSystem._currentCharacter._battleAI.DefaultAttack();
    }

    public void OnExit()
    {
        
    }

}
