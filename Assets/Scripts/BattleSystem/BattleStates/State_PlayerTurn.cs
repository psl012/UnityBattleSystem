﻿using System.Collections;
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
        if(_battleSystem._currentCharacter._isDead)
        {
            _battleSystem._battleState = BattleState.EndTurn;
        }
        else
        {
            _index = _battleSystem._currentCharacter._battlePosition;
            _battleSystem._characterPanelManager.ActivateCharacterPanel(_index);
            _battleSystem._characterUIPanels[_index].ActivateMainPanel();
            _battleSystem._currentCharacter._characterCamera.SetActionCameraOn();
            _battleSystem.ResetTargets();
            _battleSystem.PlayerTurn();
        }
    }

    public void OnExit()
    {
        _battleSystem._currentCharacter._characterCamera.SetActionCameraOff();
        _battleSystem._characterPanelManager.ActivateNeutralPanel();
    }
}
