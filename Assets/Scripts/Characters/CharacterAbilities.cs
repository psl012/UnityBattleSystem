using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
  
    public event Action<string> onUseSkill = delegate{};
    public Dictionary<string, Skill> SkillDictionary = new Dictionary<string, Skill>();

    [SerializeField] Skill[] _classSkills;
    CharacterBattleAnimator _characterBattleAnimator; // i need this to pass onto the Skill Objects
    Character _character;
    DamageDealer _damageDealer;

    protected virtual void Awake()
    {     
        SkillDictionary.Add(DictionarySkillKeys.SKILL_0, _classSkills[0]);
        SkillDictionary.Add(DictionarySkillKeys.SKILL_1, _classSkills[1]);

        _characterBattleAnimator = GetComponentInChildren<CharacterBattleAnimator>();       
        _characterBattleAnimator.onDealDamage += DealDamage;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        // It referenes from a foundation class so this must be not on awake
        _character = GetComponent<Character>();
        _damageDealer = new DamageDealer(_character._attackPower);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public void UseSkill(string skillKey, List<Character> targets, List<int> index)
    {
        _damageDealer.SetUpTargets(targets, index);
        _characterBattleAnimator.SkillAnimation(skillKey);       
    }
    

    public virtual void DealDamage() // Will deal damage using animator event 
    {
        _damageDealer.DealDamage();
    }

    public virtual void HealDamage()
    {
        Debug.Log("heal damage");
    }

    void onDestroy()
    {
        _characterBattleAnimator.onDealDamage -= DealDamage;
    }
}

public class DamageDealer
{
    List<Character> _listOfTargets;
    List<int> _listOfTargetIndex;
    float _damageHolder;
    public DamageDealer(float atkPower)
    {
        _damageHolder = atkPower;
    }

    public void SetUpTargets(List<Character> lot, List<int> lotIndex)
    {
        _listOfTargets = lot;
        _listOfTargetIndex = lotIndex;
    }

    public void DealDamage()
    {
        if (_listOfTargetIndex.Count > 0)
        {
            int targetIndex = _listOfTargetIndex[0];
            Debug.Log(_listOfTargets[targetIndex]._health + "<- health" + "I hit " + _damageHolder);
            _listOfTargetIndex.RemoveAt(0);
        }
        else
        {
            Debug.Log("No Targets left");
        }
    }
}
