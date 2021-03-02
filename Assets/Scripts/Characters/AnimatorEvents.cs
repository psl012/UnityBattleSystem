using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvents : MonoBehaviour
{
    BattleSystem _battleSystem;
    CharacterAbilities _characterAbilities;

    void Awake()
    {
        _battleSystem = FindObjectOfType<BattleSystem>();
        _characterAbilities = GetComponentInParent<CharacterAbilities>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DealDamage()
    {
        _characterAbilities.DealDamage();
    }

    public void EndTurn()
    {
        _battleSystem.EndTurn();
    }
}
