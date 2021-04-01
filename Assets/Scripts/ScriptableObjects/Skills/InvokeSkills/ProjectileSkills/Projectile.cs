using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Invocation
{
    [SerializeField] protected float _moveSpeed;
    protected override void Update()
    {
        base.Update();
    }

    public override void Activate(Character user, CharacterBattleAnimator userAnimator, Character target)
    {
        base.Activate(user, userAnimator, target);
        transform.position = userAnimator.transform.position;
    }

    public virtual void MoveToTarget()
    {
        if(Vector2.Distance(transform.position, _target.transform.position) < 0.05f)
        {
            Debug.Log("Moving finished");
            _animator.SetTrigger(DAMAGE_ANIM_TRIG);
            _isFinishedMoving = true;
        }

         transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _moveSpeed*Time.deltaTime);
    }
}
