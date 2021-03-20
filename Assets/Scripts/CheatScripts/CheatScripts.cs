using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatScripts : MonoBehaviour
{
    BattlePlacement _battlePlacement;
    BattleSystem _battleSystem;

    void Awake()
    {
        _battlePlacement = GetComponentInParent<BattlePlacement>();
        _battleSystem = FindObjectOfType<BattleSystem>();
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
            _battlePlacement._isOccupied = false;
            Destroy(gameObject);
        }
    }
}
