using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    const string NORMAL_ATTACK_TRIGGER = "NormalAttackTrigger";

    // Start is called before the first frame update
    CharacterEvents _characterEvents;
    Animator _animator;



    void Awake()
    {
        _characterEvents = GetComponent<CharacterEvents>();
        _animator = GetComponentInChildren<Animator>();

        _characterEvents.onNormalAttack += NormalAttackAnimation;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NormalAttackAnimation()
    {
        _animator.SetTrigger(NORMAL_ATTACK_TRIGGER);
    }

    void OnDestroy()
    {
        _characterEvents.onNormalAttack -= NormalAttackAnimation;     
    }
}
