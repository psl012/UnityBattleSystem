using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattleAnimator : MonoBehaviour
{
    protected const string BASE_SKILL_TRIGGER = "baseSkillTrig";
    protected const string SKILL_0_TRIGGER = "skill0Trig";
    protected const string NORMAL_ATTACK_TRIGGER = "NormalAttackTrigger";
    public Dictionary<string, Func<int>> _animationDictionary = new Dictionary<string, Func<int>>();
    protected CharacterAbilities _characterAbilities;
    protected Animator _animator;
    protected BattleSystem _battleSystem;

    protected virtual void Awake()
    {
        _battleSystem = FindObjectOfType<BattleSystem>();
        _characterAbilities = GetComponentInParent<CharacterAbilities>();
        _animator = GetComponent<Animator>();
        _characterAbilities.onDefaultAttack += DefaultAttackAnimation;
        
        _animationDictionary.Add(DictionarySkillStrings.BASE_SKILL, BaseSkillAnimation);
        _animationDictionary.Add(DictionarySkillStrings.SKILL_0, Skill0Animation);
    }
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual int BaseSkillAnimation()
    {
        _animator.SetTrigger(BASE_SKILL_TRIGGER);
        return 0;
    }

    public virtual int Skill0Animation()
    {
        _animator.SetTrigger(SKILL_0_TRIGGER);
        return 0;
    }

    protected virtual void DefaultAttackAnimation()
    {
        _animator.SetTrigger(NORMAL_ATTACK_TRIGGER);
    }

    protected virtual void OnDestroy()
    {
       _characterAbilities.onDefaultAttack -= DefaultAttackAnimation;
    }

    
    public void DealDamage()
    {
        _characterAbilities.DealDamage();
    }

    public void EndTurn()
    {
        _battleSystem.EndTurn();
    }

}
