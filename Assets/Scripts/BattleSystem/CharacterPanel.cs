using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    public int _characterPanelNumber;
    public Character _myCharacter { get; private set; }

    protected BattleSystem _battleSystem;
    protected TargetManager _targetManager;
    protected CharacterAbilities _characterAbilities;
    protected Character[] _playerTargetChars;
    protected Character[] _enemyTargetChars;
    protected TargetIcon _targetIcon;
    UIPanelChanger _uiPanelChanger;

    protected virtual void Awake()
    {
        _battleSystem = GetComponentInParent<BattleSystem>();
        _playerTargetChars = FindObjectsOfType<Player>();
        _enemyTargetChars = FindObjectsOfType<Enemy>();
        _targetIcon = FindObjectOfType<TargetIcon>();

        foreach (Character ch in _playerTargetChars)
        {
            if (ch._battlePosition == _characterPanelNumber)
            {
                _myCharacter = ch;
            }
        }
        _characterAbilities = _myCharacter.GetComponent<CharacterAbilities>();

        _targetManager = new TargetManager(_playerTargetChars, _enemyTargetChars, _characterAbilities, _targetIcon);
        _uiPanelChanger = GetComponent<UIPanelChanger>();
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
