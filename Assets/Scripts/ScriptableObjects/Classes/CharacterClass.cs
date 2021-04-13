using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Class", menuName = "Character Class")]
public class CharacterClass : ScriptableObject
{
    public string _className;
    public string _description;

    [Header("Basic Stats")]
    public float _characterLevel;
    public float _health;
    public float _mana;
    public float _attackPower;
    public float _magicPower;
    public float _defensePower;
    public float _magicDefensePower;

    [Header("Character Attributes")]
    public float _strenght;
    public float _dexterity;
    public float _intelligence;
    public float _speed;

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

    [Header("Others")]
    public float _expGivenOnDeath;

}
