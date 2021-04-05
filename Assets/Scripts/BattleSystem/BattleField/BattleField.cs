using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleField : MonoBehaviour
{
    public PlayerBattlePlacement[] _playerBattlePlacement;
    public EnemyBattlePlacement[] _enemyBattlePlacement;

    public Character[] _playerCharacters;

    [SerializeField] Transform _centerCamera;

    int _fieldPlayerSize;
    int _fieldEnemySize;
    
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
        _fieldPlayerSize = Mathf.Min(_playerBattlePlacement.Length, players.Length);
        _fieldEnemySize = Mathf.Min(_enemyBattlePlacement.Length, enemies.Length);

        for(int i = 0; i < _fieldPlayerSize; i++)
        {
            _playerBattlePlacement[i]._placedCharacterObject = players[i];   
        }

        for(int i = 0; i < _fieldEnemySize; i++)
        {
            _enemyBattlePlacement[i]._placedCharacterObject = enemies[i];   
        }

        CreateBattlers();
    }

    public void CreateBattlers()
    {
        for(int i = 0; i < _fieldPlayerSize; i++)
        {
            _playerBattlePlacement[i].CreateBattler(_centerCamera);      
        }

        for(int i = 0; i < _fieldEnemySize; i++)
        {
            _enemyBattlePlacement[i].CreateBattler(_centerCamera); 
        }

        _playerCharacters = GetComponentsInChildren<Player>();
        GameManager.instance._characterDatabase.UpdatePartyCharacters(_playerCharacters);
    }


}
