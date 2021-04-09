using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDatabase : MonoBehaviour
{
    public GameObject[] _partyMembersObjects;
    public GameObject[] _enemyObjects;

    public Character[] _partyCharacters;

    public (CharacterStats, bool)[] _characterStats = new (CharacterStats, bool)[4];
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
            _partyCharacters[0]._characterLevelManager.InitializePlayerOnLevel();
            for (int i = 0; i < _partyCharacters.Length; i++)
            {
                _characterStats[i].Item1 = new CharacterStats();
                _characterStats[i].Item1.GetDataFromOtherCharacterStats(partyCharacter[i]._characterStats);

            }
            _isPartyCharactersInitialized = true;
        }
    }

    public void UpdateDatabaseCharacterStats()
    {
        if(_characterStats == null) return;

        for(int i=0; i < _partyCharacters.Length; i++)
        {
            _characterStats[i].Item1.GetDataFromOtherCharacterStats(_partyCharacters[i]._characterStats);
          //  _characterStats[i].Item1._currentMana = _partyCharacters[i]._characterStats._currentMana;
        }
    }

    public void UpdateBattlerCharacterStats()
    {
        if(_partyCharacters.Length < 1) return;

        for (int i=0; i < _partyCharacters.Length; i++)
        {
            _partyCharacters[i]._characterStats.GetDataFromOtherCharacterStats(_characterStats[i].Item1);
            _partyCharacters[i]._characterHPMPManager.UpdateStats(_characterStats[i].Item1);
        }
    }
}





   

