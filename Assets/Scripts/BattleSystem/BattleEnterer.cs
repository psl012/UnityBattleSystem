using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnterer : MonoBehaviour
{
    public GameObject[] _players;
    public GameObject[] _enemies;

    BattleField _battleField;
    
    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialize()
    {
        _battleField = FindObjectOfType<BattleField>();  

        for(int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].GetComponent<Character>()._battlePosition = i;
        }

        SetUpBattleField();
    }

    public void SetUpBattleField()
    {
        _battleField.SetupBattleField(_players, _enemies);
    }

}
