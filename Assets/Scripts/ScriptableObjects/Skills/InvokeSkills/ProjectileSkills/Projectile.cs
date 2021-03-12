using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Invocation
{
    protected override void Update()
    {
        base.Update();
        if(!_isCasted || _isFinishedMoving) 
        {
            return;
        }
        MoveToTarget();
    }

    public override void Activate(CharacterAbilities user, List<Character> target, List<int> index)
    {
        base.Activate(user, target, index);
        transform.position = user.transform.position;
    }

    public virtual void MoveToTarget()
    {
        if(Vector2.Distance(transform.position, _listOftarget[_listOfIndex[0]].transform.position) < 0.05f)
        {
            Debug.Log("Moving finished");
            _animator.SetTrigger(DAMAGE_ANIM_TRIG);
            _isFinishedMoving = true;
        }

         transform.position = Vector2.MoveTowards(transform.position, _listOftarget[_listOfIndex[0]].transform.position, 5f*Time.deltaTime);
    }
}
