using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHPMPManager : MonoBehaviour
{
    Character _character;
    UICharacter _UICharacter;
    BattleSystem _battleSystem;

    public void InitializeUICharacter(UICharacter UICharacter)
    {
        _UICharacter = UICharacter;
    }


    public void InitializeLinkCharacter(Character character)
    {
        _character = character;
        _battleSystem = FindObjectOfType<BattleSystem>();
    }

    public void DamageMe(float damagePoint)
    {

        _character._characterStats._currentHealth -= damagePoint;
        _UICharacter?.UpdateHPText(_character._characterStats._currentHealth);
        
        if (_character._characterStats._currentHealth <= 0 && !_character._isDead)
        {
            _character._isDead = true;
        }
    }

    public void BurnMana(float manaBurnPoint)
    {
        _character._characterStats._currentMana -= manaBurnPoint;
        _UICharacter?.UpdateMPText(_character._characterStats._currentMana);
    }

    public void UpdateStats(CharacterStats dataBaseStats)
    {
        _character._characterStats._currentHealth = dataBaseStats._currentHealth;
        _UICharacter?.UpdateHPText(_character._characterStats._currentHealth);

        _character._characterStats._currentMana = dataBaseStats._currentMana;
        _UICharacter?.UpdateMPText(_character._characterStats._currentMana);
    }
}
