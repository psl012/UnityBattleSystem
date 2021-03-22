﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlacement : MonoBehaviour
{
    public int _battlePosition;
    public Transform frontBattlePlacement;
    public Transform backBattlePlacement;
    public GameObject _placedCharacterObject;

    public Character _mycharacterBattler;
    public bool _isOccupied = false;
    
    protected virtual void Awake()
    {
        
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual void CreateBattler()
    {
        _isOccupied = true;
        if(_placedCharacterObject == null) return;
        _mycharacterBattler = Instantiate(_placedCharacterObject, transform.position, Quaternion.identity, this.transform).GetComponent<Character>();
        _mycharacterBattler.TemporaryFixSetBattlePosition(_battlePosition);
        
        // For AI characters
        _mycharacterBattler._battleAI?.InitializeBattleAI();
    }
}
