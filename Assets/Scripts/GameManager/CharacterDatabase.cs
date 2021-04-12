using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDatabase : MonoBehaviour
{
    public GameObject[] _partyMembersObjects;
    public GameObject[] _enemyObjects;
    public Character[] _partyCharactersRef;
    public (CharacterStats, bool)[] _databaseCharacterStats = new (CharacterStats, bool)[4];
    bool _isPartyCharactersInitialized = false;


    public void InitializeCharacterDatabase(Character[] partyCharacters)
    {
        _partyCharactersRef = partyCharacters;
        
        if(!_isPartyCharactersInitialized)
        {
            for (int i = 0; i < _partyCharactersRef.Length; i++)
            {
                if(!_databaseCharacterStats[i].Item2)
                {
                    _partyCharactersRef[i]._characterLevelManager.InitializePlayerOnLevel();
                    _databaseCharacterStats[i].Item1 = new CharacterStats();
                    _databaseCharacterStats[i].Item1.GetDataFromOtherCharacterStats(partyCharacters[i]._characterStats);
                    _databaseCharacterStats[i].Item2 = true;
                }
            }
            _isPartyCharactersInitialized = true;
        }
    }

    public void UpdateDatabaseCharacterStats()
    {
        if(_databaseCharacterStats == null) return;

        for(int i=0; i < _partyCharactersRef.Length; i++)
        {
            _databaseCharacterStats[i].Item1.GetDataFromOtherCharacterStats(_partyCharactersRef[i]._characterStats);
        }
    }

    public void UpdateBattlerCharacterStats()
    {
        for (int i=0; i < _partyCharactersRef.Length; i++)
        {
            _partyCharactersRef[i]._characterStats.GetDataFromOtherCharacterStats(_databaseCharacterStats[i].Item1);
            _partyCharactersRef[i]._characterHPMPManager.UpdateStats(_databaseCharacterStats[i].Item1);
            _partyCharactersRef[i]._characterLevelManager.UpdateLevelStats(_databaseCharacterStats[i].Item1);
        }
    }

    public void IncreasePartyExpPoints(float points)
    {
        for (int i = 0; i < _partyCharactersRef.Length; i++)
        {
            _partyCharactersRef[i]._characterLevelManager.IncreaseExp(points);
        }
        Debug.Log("current Exp: " + _partyCharactersRef[0]._characterStats._expPoints);
    }

}





   

