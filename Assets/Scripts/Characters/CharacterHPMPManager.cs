using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHPMPManager : MonoBehaviour
{
    float _currentHP;
    float _currentMP;

    UICharacter _UICharacter;


    public void InitializeUICharacter(UICharacter UICharacter)
    {
        _UICharacter = UICharacter;
    }


    public void InitializeHealth(CharacterStats characterStats)
    {
        _currentHP = characterStats._maxHealth;
        _currentMP = characterStats._maxMana;
    }

    public void DamageMe(float damagePoint)
    {
        _currentHP -= damagePoint;
        Debug.Log(_currentHP);
        _UICharacter.UpdateHPText(_currentHP);
    }

    public void BurnMana(float manaBurnPoint)
    {
        _currentMP -= manaBurnPoint;
        _UICharacter.UpdateMPText(_currentMP);
    }
}
