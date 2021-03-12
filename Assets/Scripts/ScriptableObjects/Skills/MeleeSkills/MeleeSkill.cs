using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill Object", menuName = "Skills/Melee")]
public class MeleeSkill : Skill
{
    public override SkillType GetSkillType()
    {
        return SkillType.Melee;
    }
}
