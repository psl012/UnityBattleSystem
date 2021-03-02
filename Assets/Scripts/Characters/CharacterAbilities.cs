using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    Character _currentTarget;
    Character _character;
    float _damageHolder = 0;
    public event Action onDefaultAttack = delegate{};

    public Dictionary<string, Func<Character, int>> SingleTargetAbilityDict = new Dictionary<string, Func<Character, int>>();

    public Dictionary<string, Func<List<Character>, int>> MultiTargetAbilityDict = new Dictionary<string, Func<List<Character>, int>>();

    protected virtual void Awake()
    {     
        SingleTargetAbilityDict.Add(nameof(DefaultAttack), DefaultAttack);
        _character = GetComponent<Character>();
        _damageHolder = _character._attackPower;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual int DefaultAttack(Character target)
    {
        _currentTarget = target;
        onDefaultAttack();
        Debug.Log("sd");
        
        _damageHolder = _character._attackPower;
        return 0;
    }

    public virtual void DealDamage() // Will deal damage using animator event 
    {
        Debug.Log(_currentTarget._health + "<- health" + "I hit " + _damageHolder);
    }

    public virtual void HealDamage()
    {
        Debug.Log("heal damage");
    }
}
