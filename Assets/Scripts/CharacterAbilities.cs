using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{

    CharacterEvents _characterEvents;

    Character _currentTarget;

    public Dictionary<string, Func<Character, int>> AbilityDictionary = new Dictionary<string, Func<Character, int>>();

    protected virtual void Awake()
    {
        _characterEvents = GetComponent<CharacterEvents>();

        AbilityDictionary.Add(nameof(NormalAttack), NormalAttack);
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

    public virtual int NormalAttack(Character target)
    {
        _characterEvents.NormalAttack();
        Debug.Log(target._health + "<- health");
        return 0;
    }
}
