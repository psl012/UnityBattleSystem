using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterClass _characterClass;
    public CharacterStats _characterStats;
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
        _characterStats = new CharacterStats(_characterClass);
        _characterHPMPManager = GetComponent<CharacterHPMPManager>();
        _characterHPMPManager.InitializeLinkCharacter(this);
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
    public float _attackPower { get; private set; }
    public float _defensePower { get; private set; }
    public float _dexterity { get; private set; }
    public float _speed { get; private set; }

    public float _specialPoints { get; set; }

    public CharacterStats(CharacterClass characterClass)
    {
        _maxHealth = characterClass._health;
        _currentHealth = _maxHealth;
        _maxMana = characterClass._mana;
        _currentMana = _maxMana;
        
        _attackPower = characterClass._attackPower;
        _defensePower = characterClass._defensePower;
        _dexterity = characterClass._dexterity;
        _speed = characterClass._speed;
        _specialPoints = 0;
    }

}