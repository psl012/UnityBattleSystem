using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattleAnimator : MonoBehaviour
{
    protected const string NORMAL_ATTACK_TRIGGER = "NormalAttackTrigger";

    // Start is called before the first frame update
    protected CharacterAbilities _characterAbilities;
    protected Animator _animator;

    protected virtual void Awake()
    {
        _characterAbilities = GetComponent<CharacterAbilities>();
        _animator = GetComponentInChildren<Animator>();
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
}
