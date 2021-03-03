﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    protected BattleSystem _battleSystem;
    protected TargetManager _targetManager;
    [SerializeField] protected Character _characterOwner;
    [SerializeField] protected CharacterAbilities _characterAbilities;
    protected Character[] _playerTargetChars;
    protected Character[] _enemyTargetChars;


    protected virtual void Awake()
    {
        _battleSystem = GetComponentInParent<BattleSystem>();
        _playerTargetChars = FindObjectsOfType<Player>();
        _enemyTargetChars = FindObjectsOfType<Enemy>();

        _targetManager = new TargetManager(_playerTargetChars, _enemyTargetChars, _characterAbilities);
    }


    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual void FightButton()
    {
        _targetManager.SetAbility(nameof(_characterAbilities.DefaultAttack), BattleEnums.TargetType.Enemy);
        _battleSystem.TargetMode();
    }
    public virtual void SkillButton1()
    {
        _targetManager.SetAbility(DictionarySkillStrings.SKILL_1, BattleEnums.TargetType.Enemy);
        _battleSystem.TargetMode();
    }
    public void ChangeTargetButton(string direction)
    {
        _targetManager.ChangeTarget(direction);
    }

    public void TargetInteractButton()
    {
        _targetManager.TargetInteract();
    }


}
