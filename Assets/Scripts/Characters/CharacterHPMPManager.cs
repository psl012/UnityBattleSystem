using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHPMPManager : MonoBehaviour
{
    public float _currentHP { get; set; }
    public float _currentMP { get; set; }

    Character _character;
    UICharacter _UICharacter;


    public void InitializeUICharacter(UICharacter UICharacter)
    {
        _UICharacter = UICharacter;
    }


    public void InitializeHealth(Character character)
    {
        _character = character;
        _currentHP = _character._characterStats._maxHealth;
        _currentMP = _character._characterStats._maxMana;
    }

    public void DamageMe(float damagePoint)
    {
        _currentHP -= damagePoint;
        Debug.Log(_currentHP);
        _UICharacter?.UpdateHPText(_currentHP);
        if (_currentHP <= 0)
        {
            _character._isDead = true;
        }
    }

    public void BurnMana(float manaBurnPoint)
    {
        _currentMP -= manaBurnPoint;
        _UICharacter?.UpdateMPText(_currentMP);
    }
}
