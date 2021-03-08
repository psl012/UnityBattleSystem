using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill Object", menuName = "Skills")]
public class Skill : ScriptableObject
{
    
    public string _skillName;
    public int numberOfTargets;
}
