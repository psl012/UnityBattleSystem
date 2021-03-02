using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattleAnimator : MonoBehaviour
{
    protected const string NORMAL_ATTACK_TRIGGER = "NormalAttackTrigger";
    protected CharacterAbilities _characterAbilities;
    protected Animator _animator;
    protected BattleSystem _battleSystem;

    protected virtual void Awake()
    {
        _battleSystem = FindObjectOfType<BattleSystem>();
        _characterAbilities = GetComponentInParent<CharacterAbilities>();
        _animator = GetComponent<Animator>();
        _characterAbilities.onDefaultAttack += DefaultAttackAnimation;
    }
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
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
