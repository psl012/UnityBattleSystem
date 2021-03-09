using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    protected BattleSystem _battleSystem;
    protected TargetManager _targetManager;
    [SerializeField] protected CharacterAbilities _characterAbilities;
    protected Character[] _playerTargetChars;
    protected Character[] _enemyTargetChars;
    protected TargetIcon _targetIcon;
    UIPanelChanger _uiPanelChanger;

    protected virtual void Awake()
    {
        _battleSystem = GetComponentInParent<BattleSystem>();
        _playerTargetChars = FindObjectsOfType<Player>();
        _enemyTargetChars = FindObjectsOfType<Enemy>();
        _targetIcon = GetComponentInChildren<TargetIcon>();
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

    public void ChangeTargetButton(string direction)
    {
        _targetManager.ChangeTarget(direction);
    }

    public void TargetInteractButton()
    {
        if(_targetManager.TargetInteract())
        {
            _uiPanelChanger.ActivateMainPanel();
        }
    }


}
