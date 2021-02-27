using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvents : MonoBehaviour
{
    public static BattleEvents _battleEvents;

    public event Action onPlayerTurn = delegate{};
    public event Action onEnemyTurn = delegate{};
    public event Action onEndTurn = delegate{};

    public event Action onFightButtonPress = delegate {};

    private void Awake()
    {
        _battleEvents = this;
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
        onEndTurn();
    }


    public void FightButtonPress()
    {
        onFightButtonPress();
    }
}
