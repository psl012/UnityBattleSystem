using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterClass _characterClass;
    public TargetMark _targetMark;
    public int _battlePosition;
    public float _health { get; private set; }
    public float _mana { get; private set; }
    public float _attackPower { get; private set; }
    public float _defensePower { get; private set; }
    public float _dexterity { get; private set; }
    public float _speed { get; private set; }

    public Dictionary<string, float> _characterStats = new Dictionary<string, float>();

    public float _maxHealth{get; set;}
    public float _maxMana{get; set;}

    public float _specialPoints{get; set;}

    public virtual void Awake()
    {
        _health = _characterClass._health;
        _mana = _characterClass._mana;
        _attackPower = _characterClass._attackPower;
        _defensePower = _characterClass._defensePower;
        _dexterity = _characterClass._dexterity;
        _speed = _characterClass._speed;

        _maxHealth = _health;
        _maxMana = _mana;
        _specialPoints = 0;

        _characterStats.Add(nameof(_health), _health);
        _characterStats.Add(nameof(_mana), _mana);
        _characterStats.Add(nameof(_attackPower), _attackPower);
        _characterStats.Add(nameof(_defensePower), _defensePower);
        _characterStats.Add(nameof(_dexterity), _dexterity);
        _characterStats.Add(nameof(_speed), _speed);
    }

}
