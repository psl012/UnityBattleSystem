using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlacement : MonoBehaviour
{
    public Transform enemyFoothold;
    Character _placedCharacter;

    void Awake()
    {
        _placedCharacter = GetComponentInChildren<Character>();
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
