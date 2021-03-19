using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleField : MonoBehaviour
{
    public PlayerBattlePlacement[] _playerBattlePlacement;
    public EnemyBattlePlacement[] _enemyBattlePlacement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupBattleField(GameObject[] players, GameObject[] enemies)
    {
        int fieldPlayerSize = _playerBattlePlacement.Length;
        int fieldEnemySize = _enemyBattlePlacement.Length;

        for(int i = 0; i < fieldPlayerSize; i++)
        {
            {
                _playerBattlePlacement[i]._placedCharacterObject = players[i];
            }
        }

        for(int i = 0; i < fieldEnemySize; i++)
        {
            {
                _enemyBattlePlacement[i]._placedCharacterObject = enemies[i];
            }
        }

        CreateBattlers();

    }

    public void CreateBattlers()
    {
        foreach(PlayerBattlePlacement _pbp in _playerBattlePlacement)
        {
            _pbp.CreateBattler();
        }

        foreach(EnemyBattlePlacement _ebp in _enemyBattlePlacement)
        {
            _ebp.CreateBattler();
        }
    }


}
