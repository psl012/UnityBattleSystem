﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Skill : ScriptableObject
{

    public enum SkillType {Melee, Invocation ,Summon, Buff, Debuff}
    public string _skillName;
    public float _manacost;
    public int numberOfTargets;
    public int numberOfDamageInstance;


    public virtual void ActivateSkill(CharacterAbilities user)
    {

    }

    public virtual (int, GameObject[]) GetSkillObject()
    {
        return (0, null);
    }

    public virtual SkillType GetSkillType()
    {
        return SkillType.Melee;
    }
    
}
