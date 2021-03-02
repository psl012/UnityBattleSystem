using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditBattleAnimator : CharacterBattleAnimator
{
    protected const string BLINK_SLASH_TRIGGER = "trigBlinkSlash";

    BanditAbilities _banditAbilites;

    protected override void Awake()
    {
        base.Awake();
        _banditAbilites = GetComponent<BanditAbilities>();
        _banditAbilites.onBlinkSlash += BlinkSlashAnimation;
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

    protected virtual void BlinkSlashAnimation()
    {
        _animator.SetTrigger(BLINK_SLASH_TRIGGER);
    }
}
