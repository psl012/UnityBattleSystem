using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    const string DAMAGE_ANIM_TRIG = "damageAnimTrig";
    Animator _animator;
    Rigidbody2D _rigidBody;
    List<Character> _listOftarget;
    List<int> _listOfIndex;
    int _indexCounter = 0;
    bool _isCasted = false;
    bool _isFinishedMoving = false;
    protected BattleSystem _battleSystem;

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
        if(!_isCasted || _isFinishedMoving) 
        {
            return;
        }
        MoveToTarget();
    }

    public virtual void Activate(List<Character> target, List<int> index)
    {
        _listOftarget = target;
        _listOfIndex = index;
        _isCasted = true;
    }

    public virtual void MoveToTarget()
    {
        if(Vector2.Distance(transform.position, _listOftarget[_listOfIndex[0]].transform.position) < 0.05f)
        {
            Debug.Log("Moving finished");
            _animator.SetTrigger(DAMAGE_ANIM_TRIG);
            _isFinishedMoving = true;
        }

         transform.position = Vector2.MoveTowards(transform.position, _listOftarget[_listOfIndex[0]].transform.position, 5f*Time.deltaTime);
    }

    public virtual void DamageTarget()
    {
        Debug.Log(_listOftarget[_listOfIndex[_indexCounter]].name);
        _indexCounter++;
    }

    public virtual void EndTurn()
    {
        _battleSystem.EndTurn();
    }
}
