using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
  
    public event Action<string> onUseSkill = delegate{};
    public Dictionary<string, Skill> SkillDictionary = new Dictionary<string, Skill>();
    
    public Skill[] _classSkills;
    CharacterBattleAnimator _characterBattleAnimator; // i need this to pass onto the Skill Objects
    CharacterBattlePlacementAnimator _characterBattlePlacementAnimator;
    Character _character;
    public DamageDealer _damageDealer;


    protected virtual void Awake()
    {     
        
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {   
        // It referenes from a foundation class so this must be not on awake

    }

    public void InitializeCharacterAbilities()
    {
        if (_classSkills[0] != null) SkillDictionary.Add(DictionarySkillKeys.SKILL_0, _classSkills[0]);
        if (_classSkills[1] != null) SkillDictionary.Add(DictionarySkillKeys.SKILL_1, _classSkills[1]);
        if (_classSkills[2] != null) SkillDictionary.Add(DictionarySkillKeys.SKILL_2, _classSkills[2]);
        if (_classSkills[3] != null) SkillDictionary.Add(DictionarySkillKeys.SKILL_3, _classSkills[3]);
        _characterBattleAnimator = GetComponentInChildren<CharacterBattleAnimator>();  
        _characterBattlePlacementAnimator = GetComponentInChildren<CharacterBattlePlacementAnimator>();     
        _character = GetComponent<Character>();
        _damageDealer = new DamageDealer(_character);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public void UseSkill(string skillKey, List<Character> targets, List<int> index, BattlePlacement[] targetPlacements)
    {
        Skill selectedSkill = SkillDictionary[skillKey];

        _character._characterHPMPManager.BurnMana(selectedSkill._manacost);

        if (selectedSkill.GetSkillType() == Skill.SkillType.Melee)
        {           
                _damageDealer.SetUpTargets(targets, index);
                _characterBattleAnimator.SetBattleAnimator(targets, index);
                _characterBattlePlacementAnimator.SetBattlePlacements(index, targetPlacements, targets);
                _characterBattleAnimator.SkillAnimation(skillKey, targets.Count, CharacterBattleAnimator.SkillAnimationType.Generic); // !!! Replace me
        }
        else if (selectedSkill.GetSkillType() == Skill.SkillType.Invocation)
        {
            (int, GameObject[]) projectileTuple = selectedSkill.GetSkillObject();
            _damageDealer.SetUpTargets(targets,index);
            _characterBattleAnimator.SetBattleAnimator(targets, index);
            _characterBattlePlacementAnimator.SetBattlePlacements(index, targetPlacements, targets);
            _characterBattleAnimator.SetUpInvocation(projectileTuple.Item2, targets, index);
            _characterBattleAnimator.SkillAnimation(skillKey, targets.Count, CharacterBattleAnimator.SkillAnimationType.Generic);         
        }   
    }
    
}

public class DamageDealer
{
    List<Character> _listOfTargets;
    List<int> _listOfTargetIndex;
    Character _character;
    
    public DamageDealer(Character character)
    {
        _character = character;
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
            Debug.Log(_listOfTargets[targetIndex]._characterStats._maxHealth + "<- health" + " I hit " + _listOfTargets[targetIndex].name + " for " + _character._characterStats._attackPower);
            _listOfTargets[targetIndex]._characterHPMPManager.DamageMe(_character._characterStats._attackPower);
        }
        else
        {
            Debug.Log("No Targets left");
        }
    }

    public void NextTarget()
    {
        _listOfTargetIndex.RemoveAt(0);
    }
}
