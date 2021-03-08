using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattleAnimator : MonoBehaviour
{
    public event Action onDealDamage = delegate{};
    public Dictionary<string, string> _animationDictionary = new Dictionary<string, string>();
    protected CharacterAbilities _characterAbilities;
    protected Animator _animator;
    protected BattleSystem _battleSystem;

    protected virtual void Awake()
    {
        _battleSystem = FindObjectOfType<BattleSystem>();
        _characterAbilities = GetComponentInParent<CharacterAbilities>();
        _animator = GetComponent<Animator>();
        _animationDictionary.Add(DictionarySkillKeys.SKILL_0, DictionaryAnimationTriggers.SKILL_0);
        _animationDictionary.Add(DictionarySkillKeys.SKILL_1, DictionaryAnimationTriggers.SKILL_1);
    }
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual int SkillAnimation(string skillKey)
    {
        _animator.SetTrigger(_animationDictionary[skillKey]);
        return 0;
    }
    
    public void DealDamage()
    {
        onDealDamage();
    }

    public void EndTurn()
    {
        _battleSystem.EndTurn();
    }

}
