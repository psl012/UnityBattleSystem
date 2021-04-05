using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHPMPManager : MonoBehaviour
{
    public float _currentHP { get; set; }
    public float _currentMP { get; set; }

    Character _character;
    CharacterBattleAnimator _characterBattleAnimator;
    UICharacter _UICharacter;
    BattleSystem _battleSystem;

    public void InitializeUICharacter(UICharacter UICharacter)
    {
        _UICharacter = UICharacter;
    }


    public void InitializeHealth(Character character)
    {
        _character = character;
        _currentHP = _character._characterStats._currentHealth;
        _currentMP = _character._characterStats._currentMana;
        _battleSystem = FindObjectOfType<BattleSystem>();
        _characterBattleAnimator = GetComponentInChildren<CharacterBattleAnimator>();
    }

    public void DamageMe(float damagePoint)
    {
        _currentHP -= damagePoint;
        _character._characterStats._currentHealth -= damagePoint;
        Debug.Log(_currentHP);
        _UICharacter?.UpdateHPText(_currentHP);
        if (_currentHP <= 0 && !_character._isDead)
        {
            _character._isDead = true;
        }
    }

    public void BurnMana(float manaBurnPoint)
    {
        _currentMP -= manaBurnPoint;
        _character._characterStats._currentMana -= manaBurnPoint;
        _UICharacter?.UpdateMPText(_currentMP);
    }

    public void UpdateMana(float dataMana)
    {
        _currentMP = dataMana;
        _character._characterStats._currentMana = _currentMP;
        _UICharacter?.UpdateMPText(_currentMP);
    }
}
