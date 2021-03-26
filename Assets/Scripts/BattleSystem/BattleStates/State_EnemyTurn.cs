using System.Collections;
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
        if(_battleSystem._currentCharacter._isDead)
        {
            _battleSystem._battleState = BattleState.EndTurn;
        }

        else
        {
            _battleSystem.EnemyTurn();
            _battleSystem._characterPanelManager.ActivateNeutralPanel();      
            //  _battleSystem._characterUIPanels[0].ActivateDisablePanel();
            _battleSystem._currentCharacter._battleAI.DefaultAttack();
            _battleSystem._currentCharacter._characterCamera.SetActionCameraOn();
        }
    }

    public void OnExit()
    {
            _battleSystem._currentCharacter._characterCamera.SetActionCameraOff();
    }

}
