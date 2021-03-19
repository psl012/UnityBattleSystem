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
    int _skillTargetAvailable = 0;
    int _numberOfTargetsLeft = 0;

    List<int> _listTargetIndex = new List<int>();
    
    public TargetManager(BattlePlacement[] playerBattlePlacements, BattlePlacement[] enemyBattlePlacements,  Character[] playerTarget, Character[] enemyTarget, CharacterAbilities characterAbilities, TargetIcon targetIcon)
    {
        _characterAbilities = characterAbilities;
        _targetIcon = targetIcon;
        
        Character[] playersByBattlePostions = new Character[playerBattlePlacements.Length];
        Character[] enemiesByBattlePostions = new Character[enemyBattlePlacements.Length];

        for(int i = 0; i < playerBattlePlacements.Length; i++)
        {
            playersByBattlePostions[i] = playerBattlePlacements[i]._mycharacterBattler;
        }

        for(int i = 0; i < playerBattlePlacements.Length; i++)
        {
            enemiesByBattlePostions[i] = enemyBattlePlacements[i]._mycharacterBattler;
        }

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
        _numberOfTargetsLeft = _targetGroup.Count;
        _targetIcon.MoveToTarget(_currentTarget._targetMark.transform.position);
    
    }

    public void ChangeTarget(string direction)
    {
        void TargetMove(int i)
        {
             _targetIndex += i;
             
            int forceMoveCount = i;
            while(_listTargetIndex.Contains(_targetIndex) && ((_targetIndex < _targetGroup.Count) || (_targetIndex > -1)))
            {
                _targetIndex += i;
                forceMoveCount += i;
            }
            if (_targetIndex == _targetGroup.Count || _targetIndex == -1) // overflowed
            {
                _targetIndex -= forceMoveCount;
            }                   
        }

        if(direction == "right" && _targetIndex < _targetGroup.Count){TargetMove(1);}
        else if (direction  == "left" && _targetIndex > 0){TargetMove(-1);}

        _targetIcon.MoveToTarget(_targetGroup[_targetIndex]._targetMark.transform.position);
    }

    public bool TargetInteract()
    {
        Skill skillSelected = _characterAbilities.SkillDictionary[_actionSelected];
 
        if(_skillTargetAvailable > 0 && _numberOfTargetsLeft > 0)
        {
            _listTargetIndex.Add(_targetIndex);
            _skillTargetAvailable -= 1;
            _numberOfTargetsLeft -= 1;
            _targetGroup[_targetIndex]._targetMark.ActivateIcon();
            
            if(_targetIndex == _targetGroup.Count - 1)
            {
                ChangeTarget("left");
            }
            else
            {
                ChangeTarget("right");
            }
        }

        if(_skillTargetAvailable == 0 || _numberOfTargetsLeft == 0)
        {
            foreach(int ind in _listTargetIndex)
            {
                _targetGroup[ind]._targetMark.DeactivateIcon();
            }
            _targetIcon.MoveToTarget(new Vector3(-500, -270, 0));

            List<Character> targetGroupClone = new List<Character>();
            foreach (Character target in _targetGroup)
            {
                targetGroupClone.Add(target);
            }

            List<int> listTargetIndexClone = new List<int>();
            foreach(int tgIndex in _listTargetIndex)
            {
                listTargetIndexClone.Add(tgIndex);
            }
            _characterAbilities.UseSkill(_actionSelected, targetGroupClone, listTargetIndexClone);
            
            _targetIndex = 0;
            _listTargetIndex.Clear();

            return true;
        }
        else
        {
            return false;
        }
    }








}
