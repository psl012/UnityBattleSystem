using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattleAnimator : MonoBehaviour
{
    public event Action onDealDamage = delegate{};
    
    public enum SkillAnimationType{Generic, Unique}

    
    public Dictionary<string, string> _animationDictionary = new Dictionary<string, string>();
    protected Animator _animator;
    protected BattleSystem _battleSystem;

    List<Character> _listOfTargets = new List<Character>();
    List <int> _listOfTargetIndex = new List<int>(); 

    List<int> _indexRef;

    int _invokeCounter = 0;

    protected BattleField _battleField;

    BattlePlacement[] _targetBattlePlacements;

    Vector3 _initialPosition;
    GameObject[] _arrayOfInvokedObjects;
    Character _myCharacter;

    protected virtual void Awake()
    {
        _battleSystem = FindObjectOfType<BattleSystem>();
        _battleField = FindObjectOfType<BattleField>();
        _animator = GetComponent<Animator>();
        _myCharacter = GetComponentInParent<Character>(); 
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

    public virtual int SkillAnimation(string skillKey, int numOfTargets, SkillAnimationType skillAnimationType)
    {
        if(skillAnimationType == SkillAnimationType.Unique)
        {
            return 0;
        }
        else if (skillAnimationType == SkillAnimationType.Generic)
        {
            _animator.SetTrigger("prepGenSkillTrig");
            _animator.SetTrigger(_animationDictionary[skillKey]);
            _animator.SetInteger("numOfTargetsLocked", numOfTargets);
            return 0;        
        }
        else
        {
            return 0;
        }
    }

    public virtual int SetUpInvocation(GameObject[] arrayOfInvokedObjects, List<Character> listOfTargets, List<int> listOfTargetIndex)
    {
        _arrayOfInvokedObjects = arrayOfInvokedObjects;
        _listOfTargets = listOfTargets;
        _listOfTargetIndex = listOfTargetIndex;
        _invokeCounter = 0;
        return 0;
    }

    public virtual int InvokeObject()
    {
        int invokeObjectCounter = _invokeCounter;
        if (invokeObjectCounter >= _arrayOfInvokedObjects.Length)
        {
            invokeObjectCounter = 0;
        }

        if(_invokeCounter < _listOfTargets.Count)
        {
            GameObject invokedObject = Instantiate(_arrayOfInvokedObjects[invokeObjectCounter], transform.position, Quaternion.identity);
            invokedObject.GetComponent<Invocation>().Activate(_myCharacter._characterStats, this, _listOfTargets[_listOfTargetIndex[_invokeCounter]]);
        }
        else
        {
            Debug.LogWarning("Maximum target for this skill is reached!");
        }

        _invokeCounter++;
        return 0;
    }

    public virtual void SetBattlePlacements(List<int> index, BattlePlacement[] targetBattlePlacements)
    {
            _indexRef = index;
            _targetBattlePlacements = targetBattlePlacements;
    }

    public virtual void TeleportToBattlePlacement()
    {
        StartCoroutine(MoveToBattlePlacement(_targetBattlePlacements[_indexRef[0]].frontBattlePlacement.transform.position, 1000f));
    }

    public virtual void TeleportToRangedBattlePlacement()
    {
        StartCoroutine(MoveToBattlePlacement(_targetBattlePlacements[_indexRef[0]].rangedBattlePlacement.transform.position, 1000f));     
    }

    public virtual void TeleportBackToInitialPos()
    {
        StartCoroutine(MoveToBattlePlacement(_initialPosition, 1000f));
    }

    public IEnumerator MoveToBattlePlacement(Vector3 target, float speed)
    {
        while(Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target , speed*Time.deltaTime);
            yield return null;
        }
    }

    

    public void DealDamage()
    {
        onDealDamage();
    }

    public void DeathTrigger()
    {
        _battleSystem._numOfEnemyKilledThisTurn++;
        _animator.SetTrigger("deathTrigger");
    }

    public void EndTurnTrigger()
    {
        _animator.SetTrigger("endTurnTrigger");
    }

    public void EndTurn()
    {
        _battleSystem.EndTurn();
    }

    public void DecrementBattleSystemNumOfCharKilled()
    {
        _battleSystem._numOfEnemyKilledThisTurn--;
    }
}
