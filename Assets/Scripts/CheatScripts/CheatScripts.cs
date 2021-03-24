using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatScripts : MonoBehaviour
{
    BattlePlacement _battlePlacement;
    BattleSystem _battleSystem;

    SpriteRenderer _spriteRenderer;

    Character _character;

    void Awake()
    {
        _battlePlacement = GetComponentInParent<BattlePlacement>();
        _battleSystem = FindObjectOfType<BattleSystem>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _character = GetComponent<Character>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Kill ME!");
            _character._isDead = true;
            _battleSystem.ResetTargets();
            //_spriteRenderer.enabled = false;
        }
    }
}
