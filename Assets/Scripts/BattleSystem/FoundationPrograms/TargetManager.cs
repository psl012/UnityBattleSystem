using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager
{   
    BattleEnums.TargetType _targetType;
    CharacterAbilities _characterAbilities;
    BattlePlacement[] _allyBattlePlacements;
    BattlePlacement[] _enemyBattlePlacements;
    BattlePlacement[] _targetBattlePlacements;
    List<Character> _allyTargets = new List<Character>();    
    List<Character> _enemyTargets = new List<Character>();
    List<Character> _targetGroup = new List<Character>();
    Character _currentTarget;
    TargetIcon _targetIcon;
    string _actionSelected;
    int _targetIndex = 0;
    int _skillTargetAvailable = 0;
    int _numberOfTargetsLeft = 0;

    List<int> _listTargetIndex = new List<int>();
    
    public TargetManager(BattlePlacement[] allyBattlePlacements, BattlePlacement[] enemyBattlePlacements, CharacterAbilities characterAbilities, TargetIcon targetIcon)
    {
        _characterAbilities = characterAbilities;
        _targetIcon = targetIcon;

        _allyBattlePlacements = allyBattlePlacements;
        _enemyBattlePlacements = enemyBattlePlacements; 
        ResetTargets();
    }

    public void ResetTargets()
    {
        _allyTargets.Clear();
        for(int i = 0; i < _allyBattlePlacements.Length; i++)
        {
            if (_allyBattlePlacements[i]._isOccupied && !_allyBattlePlacements[i]._mycharacterBattler._isDead)
            {
                _allyTargets.Add(_allyBattlePlacements[i]._mycharacterBattler); 
            }
        }

        _enemyTargets.Clear();
        for(int i = 0; i < _enemyBattlePlacements.Length; i++)
        {
            if(_enemyBattlePlacements[i]._isOccupied && !_enemyBattlePlacements[i]._mycharacterBattler._isDead)
            {
                _enemyTargets.Add(_enemyBattlePlacements[i]._mycharacterBattler);
            }
        }

        if (_enemyTargets.Count <= 0)
        {
            Debug.Log("BATTLE OVER");
        }
        Debug.Log(_enemyTargets.Count);
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
            _targetGroup = _allyTargets;
            SetTargetBattlePlacement(_allyBattlePlacements, _targetGroup.Count);
        }
        else
        {
            _targetGroup = _enemyTargets;
            SetTargetBattlePlacement(_enemyBattlePlacements, _targetGroup.Count); 
        }
        _numberOfTargetsLeft = _targetGroup.Count;

        if(_targetGroup[_targetIndex]._isDead) ChangeTarget("right");
        _currentTarget = _targetGroup[_targetIndex];

        _targetIcon.MoveToTarget(_currentTarget._targetMark.transform.position);
    }

    void SetTargetBattlePlacement(BattlePlacement[] battlePlacements, int targetLength)
    {
        _targetBattlePlacements = new BattlePlacement[targetLength];

        int j = 0;
        for(int i = 0; i < battlePlacements.Length; i++)
        {
            if (battlePlacements[i]._isOccupied && !battlePlacements[i]._mycharacterBattler._isDead) 
            {
                Debug.Log(j);
                _targetBattlePlacements[j] = battlePlacements[i];
                j++;
            }       
        }
    }

    public void ChangeTarget(string direction)
    {
        bool CheckBattlePlacementEmpty()
        {
            if(_targetIndex < 0 || _targetIndex >= _targetGroup.Count) 
            {
                return false;
            }
            else
            {
                bool isBattlePlacementEmpty = (!_enemyBattlePlacements[_targetIndex]._isOccupied || _targetGroup[_targetIndex]._isDead);
                bool isIndexInTargetList = _listTargetIndex.Contains(_targetIndex);

                return isBattlePlacementEmpty || isIndexInTargetList;
            }
        }

        void TargetMove(int i)
        {
             _targetIndex += i;
             
            int forceMoveCount = i;
            int infiniteLoopCounter = 0;
            
            while(CheckBattlePlacementEmpty())
            {
                infiniteLoopCounter += 1;
                if(infiniteLoopCounter > 100){break;}
                _targetIndex += i;
                forceMoveCount += i;
            }
            Debug.Log(_targetGroup.Count);
            if (_targetIndex >= _targetGroup.Count || _targetIndex <= -1) // overflowed
            {
                _targetIndex -= forceMoveCount;
            }                   
        }

        if(direction == "right" && _targetIndex < _targetGroup.Count - 1){TargetMove(1);}
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
            
            if(_targetIndex == _targetGroup.Count - 1){ChangeTarget("left");}
            else{ChangeTarget("right");}
        }

        if(_skillTargetAvailable == 0 || _numberOfTargetsLeft == 0)
        {
            foreach(int ind in _listTargetIndex){_targetGroup[ind]._targetMark.DeactivateIcon();}
            _targetIcon.MoveToTarget(new Vector3(-500, -270, 0));

            List<Character> targetGroupClone = new List<Character>();
            foreach (Character target in _targetGroup){targetGroupClone.Add(target);}

            List<int> listTargetIndexClone = new List<int>();
            foreach(int tgIndex in _listTargetIndex){listTargetIndexClone.Add(tgIndex);}

            _characterAbilities.UseSkill(_actionSelected, targetGroupClone, listTargetIndexClone, _targetBattlePlacements);
            
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
