using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattleAnimator : MonoBehaviour
{
    public event Action onDealDamage = delegate{};
    
    public Vector3 currentLeftBattlePlacement;
    public Vector3 currentRightBattlePlacement;

    public Dictionary<string, string> _animationDictionary = new Dictionary<string, string>();
    protected Animator _animator;
    protected BattleSystem _battleSystem;

    public Transform test;

    List<int> _indexRef;

    protected BattleField _battleField;

    protected virtual void Awake()
    {
        _battleSystem = FindObjectOfType<BattleSystem>();
        _battleField = FindObjectOfType<BattleField>();
        _animator = GetComponent<Animator>();
        _animationDictionary.Add(DictionarySkillKeys.SKILL_0, DictionaryAnimationTriggers.SKILL_0);
        _animationDictionary.Add(DictionarySkillKeys.SKILL_1, DictionaryAnimationTriggers.SKILL_1);
    }
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual int SkillAnimation(string skillKey)
    {
        _animator.SetTrigger(_animationDictionary[skillKey]);
        return 0;
    }

    public virtual void SetBattlePlacements(List<int> index)
    {
        _indexRef = index;
        currentLeftBattlePlacement = _battleField._enemyBattlePlacement[index[0]].frontBattlePlacement.transform.position;
    }

    public virtual void TeleportToBattlePlacement()
    {
        StartCoroutine(MoveToBattlePlacement(_battleField._enemyBattlePlacement[_indexRef[0]].frontBattlePlacement.transform.position));
    }

    public IEnumerator MoveToBattlePlacement(Vector3 target)
    {
        while(Vector3.Distance(transform.position, target) > 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target , 1000f*Time.deltaTime);
            yield return null;
        }
    }
    

    public void DealDamage()
    {
        onDealDamage();
    }

    public void EndTurn()
    {
        _battleSystem.EndTurn();
    }

}
