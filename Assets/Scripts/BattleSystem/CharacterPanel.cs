﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    public int _characterPanelNumber;
    public Character _myCharacter { get; private set; }

    protected CharacterIcon _characterIcon;
    protected BattleSystem _battleSystem;
    protected TargetManager _targetManager;
    protected CharacterAbilities _characterAbilities;
    protected Character[] _playerTargetChars;
    protected Character[] _enemyTargetChars;
    protected TargetIcon _targetIcon;
    protected BattleField _battleField;
    UIPanelChanger _uiPanelChanger;

    protected virtual void Awake()
    {

    }

    public void InitializeCharacterPanel()
    {
        _battleSystem = GetComponentInParent<BattleSystem>();
        _battleField = FindObjectOfType<BattleField>();
        _playerTargetChars = FindObjectsOfType<Player>();
        _enemyTargetChars = FindObjectsOfType<Enemy>();
        _targetIcon = FindObjectOfType<TargetIcon>();

        foreach (PlayerBattlePlacement pb in _battleField._playerBattlePlacement)
        {
            if (pb._battlePosition == _characterPanelNumber)
            {
                _myCharacter = pb._mycharacterBattler;
            }
        }

     //   _characterIcon = _myCharacter.GetComponentInChildren<CharacterIcon>();

        _characterAbilities = _myCharacter.GetComponent<CharacterAbilities>();

        _targetManager = new TargetManager(_playerTargetChars, _enemyTargetChars, _characterAbilities, _targetIcon);
        _uiPanelChanger = GetComponent<UIPanelChanger>();
    }

   /** public void TriggerCharacterIcon(bool isOff)
    {
        if (isOff)
        {
            _characterIcon.gameObject.SetActive(true);
        }
        else
        {
            _characterIcon.gameObject.SetActive(false);
        }
    }*/

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
        _targetManager.SetAbility(DictionarySkillKeys.SKILL_0, BattleEnums.TargetType.Enemy);
        _battleSystem.TargetMode();
    }
    public virtual void SkillButton1()
    {
        _targetManager.SetAbility(DictionarySkillKeys.SKILL_1, BattleEnums.TargetType.Enemy);
        _battleSystem.TargetMode();
    }

    public virtual void SkillButton2()
    {
        _targetManager.SetAbility(DictionarySkillKeys.SKILL_2, BattleEnums.TargetType.Enemy);
        _battleSystem.TargetMode();       
    }

    public virtual void SkillButton3()
    {
        _targetManager.SetAbility(DictionarySkillKeys.SKILL_3, BattleEnums.TargetType.Enemy);
        _battleSystem.TargetMode();       
    }

    public void ChangeTargetButton(string direction)
    {
        _targetManager.ChangeTarget(direction);
    }

    public void TargetInteractButton()
    {
        if(_targetManager.TargetInteract())
        {
            // _uiPanelChanger.ActivateMainPanel();
            // _uiPanelChanger.ActivateDisablePanel();
            _battleSystem._characterPanelManager.ActivateNeutralPanel();
        }
    }


}
