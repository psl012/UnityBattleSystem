using System.Collections;
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
    protected CharacterStats _userStats;
    protected Character _user;
    protected CharacterBattleAnimator _userAnimator;

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

    public virtual void Activate(Character user,  CharacterBattleAnimator userAnimator, Character target)
    {
        _user = user;
        _userStats = user._characterStats;
        _userAnimator = userAnimator;
        _target = target;
        _isCasted = true;
    }

    public virtual void DamageTarget()
    {
        _user._characterAbilities._damageDealer.DealDamage();
    }

    public virtual void DestroyMe()
    {
        Destroy(gameObject,0.1f);
    }

    public virtual void TriggerEndTurn()
    {
        _userAnimator.EndTurnTrigger();
    }

    public virtual void PlayDeathAnimationIfDead()
    {
        _user._characterBattleAnimator.PlayTargetDeathAnimation();
    }
}
