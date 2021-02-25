using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{

    CharacterEvents _characterEvents;

    Character _currentTarget;

    public Dictionary<string, Func<Character, int>> AbilityDictionary = new Dictionary<string, Func<Character, int>>();

    void Awake()
    {
        _characterEvents = GetComponent<CharacterEvents>();

        AbilityDictionary.Add(nameof(NormalAttack), NormalAttack);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectTarget(Character target)
    {
        _currentTarget = target;
    }

    public int NormalAttack(Character target)
    {
        _characterEvents.NormalAttack();
        Debug.Log(target.name + "GGGGG");
        return 0;
    }
}
