using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill Object", menuName = "Skills")]
public class Skill : ScriptableObject
{
    
    public string _skillName;
    public int numberOfTargets;

    public int UseSkill(CharacterAbilities user, Func<int> animateFunction ,List<Character> targets, List<int> targetIndex)
    {
        user._listOfCurrentTargets = targets;
        user._listOfTargetIndex = targetIndex;
        user._damageHolder = user._character._attackPower;
        animateFunction();
        Debug.Log(user.name + "OH NO");
        return 0;
    }
}
