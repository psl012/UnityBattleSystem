using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Projectile
{
    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(!_isCasted || _isFinishedMoving) 
        {
            return;
        }
        MoveToTarget();
    }

    public override void Activate(CharacterBattleAnimator user, Character target)
    {
        base.Activate(user, target);
    }

    public override void MoveToTarget()
    {
        if(Vector2.Distance(transform.position, _target.transform.position) < 0.05f)
        {
            Debug.Log("Moving finished");
            _animator.SetTrigger(DAMAGE_ANIM_TRIG);
            _isFinishedMoving = true;
        }
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _moveSpeed*Time.deltaTime);
    }

    public override void DamageTarget()
    {
        base.DamageTarget();
    }
}
