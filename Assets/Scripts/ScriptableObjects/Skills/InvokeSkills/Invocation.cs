﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invocation : MonoBehaviour
{  
    protected const string DAMAGE_ANIM_TRIG = "damageAnimTrig";
    protected Animator _animator;
    protected Rigidbody2D _rigidBody;
    protected Character _target;
    protected int _indexCounter = 0;
    protected bool _isCasted = false;
    protected bool _isFinishedMoving = false;
    protected BattleSystem _battleSystem;
    protected CharacterBattleAnimator _user;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _battleSystem = FindObjectOfType<BattleSystem>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    public virtual void Activate(CharacterBattleAnimator user, Character target)
    {
        _user = user;
        _target = target;
        _isCasted = true;
    }

    public virtual void DamageTarget()
    {
        _target._characterHPMPManager.DamageMe(1);
    }

    public virtual void DestroyMe()
    {
        Destroy(gameObject,0.1f);
    }

    public virtual void TriggerEndTurn()
    {
        _user.EndTurnTrigger();
    }
}
