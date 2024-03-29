﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattleAnimator : MonoBehaviour
{
    public event Action onDealDamage = delegate{};
    
    public enum SkillAnimationType{Generic, Unique}
    public Dictionary<string, string> _animationDictionary = new Dictionary<string, string>();
    
    protected Animator _animator;
    protected BattleSystem _battleSystem;
    Character _myCharacter;
    Character _currentTarget;
    List<Character> _listOfTargets = new List<Character>();
    List <int> _listOfTargetIndex = new List<int>(); 
    
    int _invokeCounter = 0;
    GameObject[] _arrayOfInvokedObjects;


    protected virtual void Awake()
    {
        _battleSystem = FindObjectOfType<BattleSystem>();
        _animator = GetComponent<Animator>();
        _myCharacter = GetComponentInParent<Character>(); 
        _animationDictionary.Add(DictionarySkillKeys.SKILL_0, DictionaryAnimationTriggers.SKILL_0);
        _animationDictionary.Add(DictionarySkillKeys.SKILL_1, DictionaryAnimationTriggers.SKILL_1);
        _animationDictionary.Add(DictionarySkillKeys.SKILL_2, DictionaryAnimationTriggers.SKILL_2);
    }
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual int SkillAnimation(string skillKey, int numOfTargets, SkillAnimationType skillAnimationType)
    {
        if(skillAnimationType == SkillAnimationType.Unique)
        {
            return 0;
        }
        else if (skillAnimationType == SkillAnimationType.Generic)
        {
            _animator.SetTrigger("prepGenSkillTrig");
            _animator.SetTrigger(_animationDictionary[skillKey]);
            _animator.SetInteger("numOfTargetsLocked", numOfTargets);
            return 0;        
        }
        else
        {
            return 0;
        }
    }

    public virtual int SetUpInvocation(GameObject[] arrayOfInvokedObjects, List<Character> listOfTargets, List<int> listOfTargetIndex)
    {
        _arrayOfInvokedObjects = arrayOfInvokedObjects;
        _listOfTargets = listOfTargets;
        _listOfTargetIndex = listOfTargetIndex;
        _invokeCounter = 0;
        return 0;
    }

    public virtual int InvokeObject()
    {
        int invokeObjectCounter = _invokeCounter;
        if (invokeObjectCounter >= _arrayOfInvokedObjects.Length)
        {
            invokeObjectCounter = 0;
        }

        if(_invokeCounter < _listOfTargets.Count)
        {
            GameObject invokedObject = Instantiate(_arrayOfInvokedObjects[invokeObjectCounter], transform.position, Quaternion.identity);
            _currentTarget = _listOfTargets[_listOfTargetIndex[_invokeCounter]];
            invokedObject.GetComponent<Invocation>().Activate(_myCharacter, this, _currentTarget);
        }
        else
        {
            Debug.LogWarning("Maximum target for this skill is reached!");
        }

        _invokeCounter++;
        return 0;
    }

    public virtual void SetBattleAnimator(List<Character> listOfTargets, List<int> index)
    {
        _listOfTargets = listOfTargets;
        _listOfTargetIndex = index;
    }

    public void PlayTargetDeathAnimation()
    {
        if(_currentTarget._isDead)
        {
            _battleSystem._numOfEnemyKilledThisTurn++;
            _currentTarget._characterBattleAnimator._animator.SetTrigger("deathTrigger");
        }
        _myCharacter._characterAbilities._damageDealer.NextTarget();
    }    

    public void DealDamage()
    {
        _currentTarget = _listOfTargets[_listOfTargetIndex[0]];
        _myCharacter._characterAbilities._damageDealer.DealDamage();
        _currentTarget._characterBattleAnimator._animator.SetTrigger("damageTrigger");
        onDealDamage();
    }

    public void EndTurnTrigger()
    {
        _animator.SetTrigger("endTurnTrigger");
    }

    public void EndTurn()
    {
        _battleSystem.EndTurn();
    }

    public void DecrementBattleSystemNumOfCharKilled()
    {
        _battleSystem._numOfEnemyKilledThisTurn--;
    }
}