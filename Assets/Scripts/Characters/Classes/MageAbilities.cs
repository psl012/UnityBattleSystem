using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAbilities : CharacterAbilities
{
    const string BLINK_SLASH_TRIGGER = "trigBlinkSlash";
    public event Action onBlinkSlash = delegate{};
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        AbilityDictionary.Add(DictionarySkillStrings.SKILL_1, (2, BlinkSlash));
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public int BlinkSlash(List<Character> targets, List<int> targetIndex)
    {
        _listOfCurrentTargets = targets;
        _listOfTargetIndex = targetIndex;
        _damageHolder = _character._attackPower;
        onBlinkSlash();
        return 0;
    }
}
