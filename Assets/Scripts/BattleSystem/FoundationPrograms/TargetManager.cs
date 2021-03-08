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
    List<Character> _targetGroup = new List<Character>();
    Character _currentTarget;
    TargetIcon _targetIcon;
    string _actionSelected;
    int _targetIndex = 0;
    int _currentlytargettedGroup;
    int _skillTargetAvailable = 0;

    List<int> _listTargetIndex = new List<int>();
    
    public TargetManager(Character[] playerTarget, Character[] enemyTarget, CharacterAbilities characterAbilities, TargetIcon targetIcon)
    {
        _characterAbilities = characterAbilities;
        _targetIcon = targetIcon;

        Character[] playersByBattlePostions = MergeSort.charactermergeSort(playerTarget, true, MergeSort.SortType.BattlePosition);
        Character[] enemiesByBattlePostions = MergeSort.charactermergeSort(enemyTarget, true, MergeSort.SortType.BattlePosition);


        foreach (Character ch in playersByBattlePostions)
        {
            _playerTargets.Add(ch);
        }
        
        foreach (Character ch in enemiesByBattlePostions)
        {
            _enemyTargets.Add(ch);
        }
    }

    public void SetAbility(string abilitySelected, BattleEnums.TargetType targetType)
    {
        _actionSelected = abilitySelected;
        _targetType = targetType;
        _skillTargetAvailable = _characterAbilities.SkillDictionary[abilitySelected].numberOfTargets;
        SetTarget(targetType);
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
        _targetIcon.MoveToTarget(_currentTarget._targetMark.transform.position);
    
    }
    public void ChangeTarget(string direction)
    {             
        if(direction == "right" && _targetIndex < _targetGroup.Count)
        {
            _targetIndex += 1;

            int forceMoveCount = 1;
            while(_listTargetIndex.Contains(_targetIndex) && (_targetIndex < _targetGroup.Count))
            {
                _targetIndex += 1;
                forceMoveCount += 1;
            }
            if (_targetIndex == _targetGroup.Count)
            {
                _targetIndex -= forceMoveCount;
            }
        }
        else if(direction  == "left" && _targetIndex > 0)
        {
            _targetIndex -= 1;

            int forceMoveCount = 1;
            while(_listTargetIndex.Contains(_targetIndex) && (_targetIndex > -1))
            {
                _targetIndex -= 1;
                forceMoveCount += 1;
            }
            if (_targetIndex == -1)
            {
                _targetIndex += forceMoveCount;
            }
        }
        _targetIcon.MoveToTarget(_targetGroup[_targetIndex]._targetMark.transform.position);
    }

    public bool TargetInteract()
    {
   //     (int, Func<List<Character>, List<int>, int>) skillSelected = _characterAbilities.AbilityDictionary[_actionSelected];
        Skill skillSelected = _characterAbilities.SkillDictionary[_actionSelected];
        List<Character> targetGroup = _targetGroup;

        if(_skillTargetAvailable > 0)
        {
            _listTargetIndex.Add(_targetIndex);
            _skillTargetAvailable -= 1;
            targetGroup[_targetIndex]._targetMark.ActivateIcon();
            
            if(_targetIndex == targetGroup.Count - 1)
            {
                ChangeTarget("left");
            }
            else
            {
                ChangeTarget("right");
            }
        }

        if(_skillTargetAvailable == 0)
        {
            foreach(int ind in _listTargetIndex)
            {
                _targetGroup[ind]._targetMark.DeactivateIcon();
            }
            _targetIcon.MoveToTarget(new Vector3(-500, -270, 0));

           Func<int> animationCall = _characterAbilities._characterBattleAnimator._animationDictionary[_actionSelected];
         //   skillSelected.UseSkill(_characterAbilities, animationCall, _targetGroup, _listTargetIndex);
            _characterAbilities.UseSkill(_actionSelected, _targetGroup, _listTargetIndex);
            return true;
        }
        else
        {
            return false;
        }
    }








}
