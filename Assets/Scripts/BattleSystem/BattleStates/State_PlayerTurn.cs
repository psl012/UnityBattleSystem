using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_PlayerTurn : IState
{
    BattleEvents _battleEvents;
    Character _player;

    public State_PlayerTurn(BattleEvents battleEvents, Character player)
    {
        _battleEvents = battleEvents;
    }
    // Start is called before the first frame update
    public void Tick()
    {

    }

    public void OnEnter()
    {
        _battleEvents.PlayerTurn();
    }

    public void OnExit()
    {
        
    }
}
