using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    public List<Character> _listOfCurrentTargets;
    public List<int> _listOfTargetIndex;
    public Character _character;
    public float _damageHolder = 0;
    public event Action onDefaultAttack = delegate{};
    public Skill _baseSkill;

    public Dictionary<string, (int, Func<List<Character>, List<int>, int>)> AbilityDictionary = new Dictionary<string,(int, Func<List<Character>, List<int>, int>)>();

    public Dictionary<string, Func<List<Character>, int>> MultiTargetAbilityDict = new Dictionary<string, Func<List<Character>, int>>();

    public Dictionary<string, Skill> SkillDictionary = new Dictionary<string, Skill>();
    public CharacterBattleAnimator _characterBattleAnimator {get; private set;} // i need this to pass onto the Skill Objects

    protected virtual void Awake()
    {     
        _characterBattleAnimator = GetComponentInChildren<CharacterBattleAnimator>();
        AbilityDictionary.Add(nameof(DefaultAttack),(1, DefaultAttack));

        SkillDictionary.Add(DictionarySkillStrings.BASE_SKILL, _baseSkill);

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

    public virtual int DefaultAttack(List<Character> target, List<int> targetIndex)
    {
        _listOfCurrentTargets = target;
        _listOfTargetIndex = targetIndex;
        onDefaultAttack();
        Debug.Log("sd");
        
        _damageHolder = _character._attackPower;
        return 0;
    }

    public virtual void DealDamage() // Will deal damage using animator event 
    {
        if (_listOfTargetIndex.Count > 0)
        {
            int targetIndex = _listOfTargetIndex[0];
            Debug.Log(_listOfCurrentTargets[targetIndex]._health + "<- health" + "I hit " + _damageHolder);
            _listOfTargetIndex.RemoveAt(0);
        }
        else
        {
            Debug.Log("No Targets left");
        }
    }

    public virtual void HealDamage()
    {
        Debug.Log("heal damage");
    }
}
