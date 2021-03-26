using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainInvocation : MonoBehaviour
{  
    protected const string DAMAGE_ANIM_TRIG = "damageAnimTrig";
    protected Animator _animator;
    protected Rigidbody2D _rigidBody;
    protected List<Character> _listOftarget;
    protected List<int> _listOfIndex;
    protected int _indexCounter = 0;
    protected bool _isCasted = false;
    protected bool _isFinishedMoving = false;
    protected BattleSystem _battleSystem;
    protected CharacterBattleAnimator _user;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _battleSystem = FindObjectOfType<BattleSystem>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    public virtual void Activate(CharacterBattleAnimator user, List<Character> target, List<int> index)
    {
        _user = user;
        _listOftarget = target;
        _listOfIndex = index;
        _isCasted = true;
    }

    public virtual void DamageTarget()
    {
        Debug.Log(_listOftarget[_listOfIndex[_indexCounter]].name);
        _indexCounter++;
    }

    public virtual void DestroyMe()
    {
        Destroy(gameObject,1f);
    }

    public virtual void EndTurn()
    {
        _battleSystem.EndTurn();
    }
}
