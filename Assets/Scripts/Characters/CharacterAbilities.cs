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
        if (_classSkills[2] != null) SkillDictionary.Add(DictionarySkillKeys.SKILL_2, _classSkills[2]);
        if (_classSkills[3] != null) SkillDictionary.Add(DictionarySkillKeys.SKILL_3, _classSkills[3]);
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
        Skill selectedSkill = SkillDictionary[skillKey];
       
        if (selectedSkill._skillType == Skill.SkillType.Melee)
        {
                Debug.Log("target: "+ targets[0]);
                 Debug.Log("index: "+ index[0]);
               
                _damageDealer.SetUpTargets(targets, index);
                _characterBattleAnimator.SkillAnimation(skillKey);
        }
        else if (selectedSkill._skillType == Skill.SkillType.Projectile)
        {
            (int, GameObject) projectileTuple = selectedSkill.GetSkillObject();
            GameObject[] projectiles = new GameObject[projectileTuple.Item1]; 
          
            Debug.Log("target: "+ targets[0]);
            Debug.Log("index: "+ index[0]);

            for(int i=0; i < projectileTuple.Item1; i++)
            {
                projectiles[i] = Instantiate(projectileTuple.Item2, transform.position, Quaternion.identity);
                projectiles[i].GetComponent<Projectile>().Activate(targets, index);
            }            
        }
        else if (selectedSkill._skillType == Skill.SkillType.Invocation)
        {
            (int, GameObject) invokeTuple = selectedSkill.GetSkillObject();
            GameObject[] invocations = new GameObject[invokeTuple.Item1];

            Debug.Log("target: "+ targets[0]);
            Debug.Log("index: "+ index[0]);      

            int indexCounter = 0;
            for(int i=0; i<invokeTuple.Item1; i++)
            {
                Character tg = targets[index[indexCounter]];
                invocations[i] = Instantiate(invokeTuple.Item2, tg.transform.position , Quaternion.identity);
                invocations[i].GetComponent<Invocation>().Activate(targets, index);
                indexCounter += 1;
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
            Debug.Log(_listOfTargets[targetIndex]._health + "<- health" + "I hit " + _damageHolder);
            _listOfTargetIndex.RemoveAt(0);
        }
        else
        {
            Debug.Log("No Targets left");
        }
    }
}
