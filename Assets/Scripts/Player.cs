using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{


    public override void Awake()
    {
        base.Awake();
        _maxHealth = _health;
        _maxMana = _mana;
        _specialPoints = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



}
