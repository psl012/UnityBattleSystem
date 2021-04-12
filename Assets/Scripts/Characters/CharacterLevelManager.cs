using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevelManager : MonoBehaviour
{
    public float _characterLevel;

    [Header("StatLevelUpIncrements")]
    public float _healthUp;
    public float _manaUp;
    public float _attackPowerUp;
    public float _magicPowerUp;
    public float _defensePowerUp;
    public float _magicDefensePowerUp;
    public float _strenghtUp;
    public float _dexterityUp;
    public float _intelligenceUp;
    public float _speedUp;
  
    CharacterStats _characterStats;
    UICharacter _uiCharacter;

    void Awake()
    {
        _characterStats = GetComponent<Character>()._characterStats;
        _characterStats._level = _characterLevel;
    }
    
    public void InitializeUICharacter(UICharacter uiCharacter)
    {
        _uiCharacter = uiCharacter;
    }

    public void InitializePlayerOnLevel()
    {
        for(int i=0; i < _characterLevel; i++)
        {
            LevelUp(false);
        }
    }

    public void IncreaseExp(float points)
    {
        _characterStats._expPoints += points;
        if(_characterStats._expPoints >= 100)
        {
            _characterStats._expPoints -= 100;
            LevelUp();
        }
        Debug.Log("My ExpPoints: " + _characterStats._expPoints);
        _uiCharacter.UpdateExpText();

    }

    public void LevelUp(bool initialized = true)
    {
        if (initialized)
        {
            _characterStats._level += 1;
        }

        _characterStats._maxHealth += _healthUp;
        _characterStats._currentHealth = _characterStats._maxHealth;
        
        _characterStats._maxMana += _manaUp;
        _characterStats._currentMana = _characterStats._maxMana;

        _characterStats._attackPower += _attackPowerUp;
        _characterStats._defensePower +=_defensePowerUp;
        _characterStats._magicDefensePower += _magicDefensePowerUp;
        _characterStats._dexterity += _dexterityUp;
        _characterStats._speed += _speedUp;

        Debug.Log("This is my Level: " + name + _characterStats._level);
       // _uiCharacter.UpdateHPText(_characterStats._currentHealth);
    }

    public void UpdateLevelStats(CharacterStats dataStats)
    {
        _characterStats._expPoints = dataStats._expPoints;
        _uiCharacter?.UpdateExpText();
    }
}
