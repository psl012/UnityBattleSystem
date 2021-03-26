using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill Object", menuName = "Skills/Invoke")]
public class InvokeSkill : Skill
{
    public int _numberOfInvokes;
    public GameObject[] _invoke;

    public override (int, GameObject[]) GetSkillObject()
    {
        return (_numberOfInvokes, _invoke);
    }

    public override SkillType GetSkillType()
    {
        return SkillType.Invocation;
    }
}
