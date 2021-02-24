using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float _health;
    public float _mana;
    public float _attackPower;
    public float _defensePower;
    public float _evasionPower;
    public float _speed;

    public Dictionary<string, float> _characterStats = new Dictionary<string, float>();

    public float _maxHealth{get; set;}
    public float _maxMana{get; set;}

    public float _specialPoints{get; set;}

    public virtual void Awake()
    {
        _characterStats.Add(nameof(_health), _health);
        _characterStats.Add(nameof(_mana), _mana);
        _characterStats.Add(nameof(_attackPower), _attackPower);
        _characterStats.Add(nameof(_defensePower), _defensePower);
        _characterStats.Add(nameof(_evasionPower), _evasionPower);
        _characterStats.Add(nameof(_speed), _speed);
    }

}
