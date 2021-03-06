﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAI : MonoBehaviour
{
    Character _character;

    List<Character> _allyTargets = new List<Character>();
    List<Character> _enemyTargets = new List<Character>();
    


    float _attackPower;


    // Start is called before the first frame update
    void Start()
    {
        _character = GetComponent<Character>();
        _attackPower = _character._attackPower;
        FindTargets();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DefaultAttack()
    {
        
    }

    void FindTargets()
    {
        if(tag=="Enemy")
        {
            _allyTargets.AddRange(FindObjectsOfType<Enemy>());
            _enemyTargets.AddRange(FindObjectsOfType<Player>());
        }
        else
        {
            _allyTargets.AddRange(FindObjectsOfType<Player>());
            _enemyTargets.AddRange(FindObjectsOfType<Enemy>());    
        }
    }


}
