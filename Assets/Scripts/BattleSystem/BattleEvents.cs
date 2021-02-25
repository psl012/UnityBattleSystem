using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEvents : MonoBehaviour
{
    public event Action onPlayerTurn = delegate{};
    public event Action onEnemyTurn = delegate{};

    public event Action onEndTurn = delegate{};
    
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
}
