using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    Character _currentTarget;

    public event Action onDefaultAttack = delegate{};

    public Dictionary<string, Func<Character, int>> SingleTargetAbilityDict = new Dictionary<string, Func<Character, int>>();

    public Dictionary<string, Func<List<Character>, int>> MultiTargetAbilityDict = new Dictionary<string, Func<List<Character>, int>>();

    protected virtual void Awake()
    {     
        SingleTargetAbilityDict.Add(nameof(DefaultAttack), DefaultAttack);
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual void SelectTarget(Character target)
    {
        _currentTarget = target;
    }

    public virtual int DefaultAttack(Character target)
    {
        onDefaultAttack();
        Debug.Log("sd");
        Debug.Log(target._health + "<- health");
        return 0;
    }
}
