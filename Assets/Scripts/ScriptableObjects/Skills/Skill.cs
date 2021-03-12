using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill Object", menuName = "Skills/Melee")]
public class Skill : ScriptableObject
{
    public enum SkillType {Melee, Projectile, Invocation ,Summon, Buff, Debuff}
    public SkillType _skillType;
    public string _skillName;
    public int numberOfTargets;

    public virtual void ActivateSkill(CharacterAbilities user)
    {

    }

    public virtual (int, GameObject) GetSkillObject()
    {
        return (0, null);
    }
    
}
