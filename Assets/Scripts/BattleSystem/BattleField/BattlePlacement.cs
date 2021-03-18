using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlacement : MonoBehaviour
{
    public int _battlePosition;
    public Transform enemyFoothold;
    Character _placedCharacter;

    protected virtual void Awake()
    {
        _placedCharacter = GetComponentInChildren<Character>();
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
}
