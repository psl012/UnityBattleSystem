using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invocation : MonoBehaviour
{
    const string DAMAGE_ANIM_TRIG = "damageAnimTrig";
    Animator _animator;
    List<Character> _listOftarget;
    List<int> _listOfIndex;
    int _indexCounter = 0;
    bool _isCasted = false;
    protected BattleSystem _battleSystem;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _battleSystem = FindObjectOfType<BattleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Activate(List<Character> target, List<int> index)
    {
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
