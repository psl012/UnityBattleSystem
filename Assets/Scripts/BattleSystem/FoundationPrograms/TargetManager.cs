using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager
{   
    BattleEnums.TargetType _targetType;
    CharacterAbilities _characterAbilities;
    List<Character> _playerTargets = new List<Character>();    
    List<Character> _enemyTargets = new List<Character>();
    List<Character> _targetGroup = new List<Character>()    ;
    Character _currentTarget;

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
        SetTarget(targetType);
        Debug.Log(_targetGroup.Count);
        Debug.Log(_targetGroup[0]._health);
        Debug.Log(_targetGroup[1]._health);
    }

    public void ChangeTarget(string direction)
    {             
        if(direction == "right" && _targetIndex < _targetGroup.Count - 1)
        {
            _targetIndex += 1;
        }
        else if(direction  == "left" && _targetIndex > 0)
        {
            _targetIndex -= 1;
        }
        

    }

    public void TargetInteract()
    {
        Debug.Log("Target Index: " + _targetIndex);
        Debug.Log(_targetGroup[_targetIndex]._health);     
        _characterAbilities.SingleTargetAbilityDict[_actionSelected](_targetGroup[_targetIndex]);
    }


    void SetTarget(BattleEnums.TargetType targetType)
    {
        if (_targetType == BattleEnums.TargetType.Friend)
        {
            _targetGroup = _playerTargets;
            _currentTarget = _playerTargets[0];
        }
        else
        {
            _targetGroup = _enemyTargets;
            _currentTarget = _enemyTargets[0];
        }
    }






}
