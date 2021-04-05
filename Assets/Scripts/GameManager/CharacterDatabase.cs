using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDatabase : MonoBehaviour
{
    public GameObject[] _partyMembersObjects;
    public Character[] _partyCharacters;
    public CharacterStats[] _characterStats = new CharacterStats[2];

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePartyCharacters(Character[] partyCharacter)
    {

        _partyCharacters = partyCharacter;
        
        if(_characterStats[0] == null)
        {
        for(int i = 0; i < _partyCharacters.Length; i++)
        {
             _characterStats[i] = new CharacterStats(_partyCharacters[0]._characterClass);
        }
        }
        Debug.Log("DAPAT 10: " + partyCharacter[0]._characterStats._currentMana);

    }

    public void UpdateCharacterStats()
    {
        if(_characterStats == null) return;
        _characterStats[0]._currentMana = _partyCharacters[0]._characterStats._currentMana;
        Debug.Log("tessss: " + _characterStats[0]._currentMana);
    }

    public void ReadStat1()
    {
        if(_partyCharacters.Length < 1) return;
        _partyCharacters[0]._characterHPMPManager.UpdateMana(_characterStats[0]._currentMana);
        Debug.Log("OGMOMO" + _partyCharacters[0]._characterStats._currentMana);
        Debug.Log("MOMO" + _characterStats[0]?._currentMana);
    }
}
