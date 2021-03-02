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
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public int BlinkSlash(List<Character> targets)
    {
        List<Character> targetList = new List<Character>();
        int targetCount = 3;
        targetCount = Mathf.Min(targetCount, targets.Count);

        if (targets.Count<=1)
        {   
            targetList.Add(targets[0]);
        }
        else
        {
            for (int i = 0; i < targetCount; i++)
            {
                int targetIndex = UnityEngine.Random.Range(0, targets.Count);   
                targetList.Add(targets[targetIndex]);
                targets.RemoveAt(targetIndex);
            }     
        }
        foreach(Character ch in targetList)
        {
            Debug.Log(ch.name + "attack enemy");
        }

        onBlinkSlash();
        return 0;
    }
}
