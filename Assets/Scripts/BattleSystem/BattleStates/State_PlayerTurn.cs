using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_PlayerTurn : IState
{
    BattleSystem _battleSystem;
    Character _player;

    public State_PlayerTurn(BattleSystem battleSystem, Character player)
    {
        _battleSystem = battleSystem;
    }
    // Start is called before the first frame update
    public void Tick()
    {

    }

    public void OnEnter()
    {
        _battleSystem.PlayerTurn();
        Debug.Log("GGG");
    }

    public void OnExit()
    {
        
    }
}
