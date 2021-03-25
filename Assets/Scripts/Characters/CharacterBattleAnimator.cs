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

    BattlePlacement[] _targetBattlePlacements;

    Vector3 _initialPosition;

    protected virtual void Awake()
    {
        _battleSystem = FindObjectOfType<BattleSystem>();
        _battleField = FindObjectOfType<BattleField>();
        _animator = GetComponent<Animator>();
        _animationDictionary.Add(DictionarySkillKeys.SKILL_0, DictionaryAnimationTriggers.SKILL_0);
        _animationDictionary.Add(DictionarySkillKeys.SKILL_1, DictionaryAnimationTriggers.SKILL_1);
        _initialPosition = _animator.transform.position;
    }
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual int SkillAnimation(string skillKey, int numOfTargets, bool isUniqueSkillAnim)
    {
        if(isUniqueSkillAnim)
        {
            return 0;
        }
        else
        {
            _animator.SetTrigger("prepGenSkillTrig");
            _animator.SetTrigger(_animationDictionary[skillKey]);
            _animator.SetInteger("numOfTargetsLocked", numOfTargets);
            return 0;
        }
    }

    public virtual void SetBattlePlacements(List<int> index, BattlePlacement[] targetBattlePlacements)
    {
            _indexRef = index;
            _targetBattlePlacements = targetBattlePlacements;
      //      currentLeftBattlePlacement = _battleField._enemyBattlePlacement[index[0]].frontBattlePlacement.transform.position;
    }

    public virtual void TeleportToBattlePlacement()
    {
        StartCoroutine(MoveToBattlePlacement(_targetBattlePlacements[_indexRef[0]].frontBattlePlacement.transform.position, 1000f));
    }

    public virtual void TeleportBackToInitialPos()
    {
        Debug.Log("hello");
        StartCoroutine(MoveToBattlePlacement(_initialPosition, 1000f));
    }

    public IEnumerator MoveToBattlePlacement(Vector3 target, float speed)
    {
        while(Vector3.Distance(transform.position, target) > 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target , speed*Time.deltaTime);
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
