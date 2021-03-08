using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAbilities : CharacterAbilities
{
    const string BLINK_SLASH_TRIGGER = "trigBlinkSlash";
    public event Action onBlinkSlash = delegate{};
    public List<Skill> _mageSkills;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        SkillDictionary.Add(DictionarySkillStrings.SKILL_0,_mageSkills[0]);
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

}
