using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDatabase : MonoBehaviour
{
    public GameObject[] _partyMembersObjects;
    public Character[] _partyCharacters;
    public CharacterStats[] _characterStats = new CharacterStats[4];
    bool _isPartyCharactersInitialized = false;


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
        
        if(!_isPartyCharactersInitialized)
        {
            for(int i = 0; i < _partyCharacters.Length; i++)
            {
                _characterStats[i] = new CharacterStats(_partyCharacters[i]._characterClass);
            }
            _isPartyCharactersInitialized = true;
        }
    }

    public void UpdateDatabaseCharacterStats()
    {
        if(_characterStats == null) return;

        for(int i=0; i < _partyCharacters.Length; i++)
        {
            _characterStats[i]._currentHealth = _partyCharacters[i]._characterStats._currentHealth;
            _characterStats[i]._currentMana = _partyCharacters[i]._characterStats._currentMana;
        }
    }

    public void UpdateBattlerCharacterStats()
    {
        if(_partyCharacters.Length < 1) return;

        for (int i=0; i < _partyCharacters.Length; i++)
        {
            _partyCharacters[i]._characterHPMPManager.UpdateStats(_characterStats[i]);
        }
    }
}
