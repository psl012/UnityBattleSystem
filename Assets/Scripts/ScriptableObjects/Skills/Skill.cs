using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Skill : ScriptableObject
{

    public enum SkillType {Melee, Invocation ,Summon, Buff, Debuff}
    public string _skillName;
    public int numberOfTargets;

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
