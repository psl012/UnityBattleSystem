using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Class", menuName = "Character Class")]
public class CharacterClass : ScriptableObject
{
    public string _className;
    public string _description;

    [Header("Basic Stats")]
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
}
