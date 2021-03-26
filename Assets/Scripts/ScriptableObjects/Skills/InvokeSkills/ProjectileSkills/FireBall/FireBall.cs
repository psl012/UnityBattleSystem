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
    }

    public override void Activate(CharacterBattleAnimator user, Character target)
    {
        base.Activate(user, target);
    }

    public override void MoveToTarget()
    {
        base.MoveToTarget();
    }

    public override void DamageTarget()
    {
        base.DamageTarget();
    }

    public override void EndTurn()
    {
        base.EndTurn();
    }
}
