using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_PlayerTurn : IState
{
    BattleSystem _battleSystem;
    Character _player;
    int _index;

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
        _index = _battleSystem._currentCharacterIndex;
        _battleSystem._characterUIPanels[_index].ActivateMainPanel();
        _battleSystem.PlayerTurn();
    }

    public void OnExit()
    {
        _battleSystem._characterUIPanels[_index].ActivateDisablePanel();     
    }
}
