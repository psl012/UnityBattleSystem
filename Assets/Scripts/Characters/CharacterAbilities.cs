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
        _characterBattleAnimator.onDealDamage += DealDamage;
        _character = GetComponent<Character>();
        _damageDealer = new DamageDealer(_character._attackPower);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public void UseSkill(string skillKey, List<Character> targets, List<int> index, BattlePlacement[] targetPlacements)
    {
        Skill selectedSkill = SkillDictionary[skillKey];
     
        if (selectedSkill.GetSkillType() == Skill.SkillType.Melee)
        {           
                _damageDealer.SetUpTargets(targets, index);
                _characterBattleAnimator.SetBattlePlacements(index, targetPlacements);
                _characterBattleAnimator.SkillAnimation(skillKey, false); // !!! Replace me
        }
        else if (selectedSkill.GetSkillType() == Skill.SkillType.Invocation)
        {
            (int, GameObject) projectileTuple = selectedSkill.GetSkillObject();
            GameObject[] projectiles = new GameObject[projectileTuple.Item1]; 
 
            for(int i=0; i < projectileTuple.Item1; i++)
            {
                projectiles[i] = Instantiate(projectileTuple.Item2, transform.position, Quaternion.identity);
                projectiles[i].GetComponent<Invocation>().Activate(this, targets, index);
            }            
        }   
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
            Debug.Log(_listOfTargets[targetIndex]._health + "<- health" + " I hit " + _listOfTargets[targetIndex].name + " for " + _damageHolder);
            _listOfTargetIndex.RemoveAt(0);
        }
        else
        {
            Debug.Log("No Targets left");
        }
    }
}
