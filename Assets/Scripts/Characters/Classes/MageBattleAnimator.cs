using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBattleAnimator : CharacterBattleAnimator
{
    protected const string BLINK_SLASH_TRIGGER = "trigBlinkSlash";
   
    MageAbilities _mageAbilites;
    protected override void Awake()
    {
        base.Awake();
        _mageAbilites = GetComponentInParent<MageAbilities>();
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

    protected virtual int BlinkSlashTrigger()
    {
        _animator.SetTrigger(BLINK_SLASH_TRIGGER);
        return 0;
    }

    
}
