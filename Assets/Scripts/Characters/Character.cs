using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterClass _characterClass;
    public CharacterStats _characterStats;
    public CharacterLevelManager _characterLevelManager;
    public CharacterHPMPManager _characterHPMPManager;
    public TargetMark _targetMark;
    public int _battlePosition;
    public bool _isDead;

    public BattleAI _battleAI{get; set;}

    public CharacterCamera _characterCamera{get; set;}

    public CharacterAbilities _characterAbilities;

    public CharacterBattleAnimator _characterBattleAnimator;

    public virtual void Awake()
    {
        _characterStats = new CharacterStats();
        _characterStats.GetDataFromCharacterClass(_characterClass);
        _characterHPMPManager = GetComponent<CharacterHPMPManager>();
        _characterHPMPManager.InitializeLinkCharacter(this);
        _characterLevelManager = GetComponent<CharacterLevelManager>();
        _battleAI = GetComponent<BattleAI>();
        _characterAbilities = GetComponent<CharacterAbilities>();
        _characterAbilities?.InitializeCharacterAbilities();
        _characterCamera = GetComponentInChildren<CharacterCamera>();
        _characterBattleAnimator = GetComponentInChildren<CharacterBattleAnimator>();
    }

}

public class CharacterStats
{
    public float _maxHealth { get; set; }
    public float _currentHealth;
    public float _maxMana { get; set; }
    public float _currentMana;
    public float _attackPower { get; set; }
    public float _defensePower { get;  set; }
    public float _magicDefensePower {get;  set;}
    public float _dexterity { get; set; }
    public float _speed { get; set; }

    public float _specialPoints { get; set; }
    public float _expPoints{get; set;}
    public float _characterLevel {get; set;}
    CharacterClass _characterClass;

    public void GetDataFromCharacterClass(CharacterClass characterClass)
    {
        _characterClass = characterClass;

        _maxHealth = characterClass._health;
        _currentHealth = _maxHealth;
        _maxMana = characterClass._mana;
        _currentMana = _maxMana;
        
        _attackPower = characterClass._attackPower;
        _defensePower = characterClass._defensePower;
        _magicDefensePower = characterClass._defensePower;
        _dexterity = characterClass._dexterity;
        _speed = characterClass._speed;
        
        _specialPoints = 0;
        _expPoints = 0;
    }

    public void GetDataFromOtherCharacterStats(CharacterStats characterStats)
    {
        _maxHealth = characterStats._maxHealth;
        _currentHealth = characterStats._currentHealth;
        _maxMana = characterStats._maxMana;
        _currentMana = characterStats._currentMana;

        _attackPower = characterStats._attackPower;
        _defensePower = characterStats._defensePower;
        _magicDefensePower = characterStats._defensePower;
        _dexterity = characterStats._dexterity;
        _speed = characterStats._speed;

        _specialPoints = 0;
        _expPoints = 0;
    }
}