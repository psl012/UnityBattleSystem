using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager
{   
    BattleEnums.TargetType _targetType;
    [SerializeField] CharacterAbilities _characterAbilities;
    List<Character> _playerTargets = new List<Character>();    
    List<Character> _enemyTargets = new List<Character>();  
    string _actionSelected;
    int _targetIndex = 0;
    
    public TargetManager(Character[] playerTarget, Character[] enemyTarget, CharacterAbilities characterAbilities)
    {
        _characterAbilities = characterAbilities;

        foreach (Character ch in playerTarget)
        {
            _playerTargets.Add(ch);
        }
        
        foreach (Character ch in enemyTarget)
        {
            _enemyTargets.Add(ch);
        }
    }

    public void SetAbility(string abilitySelected, BattleEnums.TargetType targetType)
    {
        _actionSelected = abilitySelected;
        _targetType = targetType;
    }

    public void ChangeTarget(string direction)
    {
       // GetTargetCount = (x) => x == BattleEnums.TargetType.Friend ? _playerTargets.Count : _enemyTargets.Count;
        int currentTargetCount;
        if (_targetType == BattleEnums.TargetType.Friend)
        {
            currentTargetCount = _playerTargets.Count;
        }
        else
        {
            currentTargetCount = _enemyTargets.Count;
        }
        
        if(direction == "right" && _targetIndex < currentTargetCount)
        {
            _targetIndex += 1;
        }
        else if(direction  == "left" && _targetIndex >0)
        {
            _targetIndex -= 1;
        }
        

    }

    public void TargetInteract()
    {
        Debug.Log(_targetType);
        _characterAbilities.AbilityDictionary[_actionSelected](_playerTargets[_targetIndex]);
    }






}
