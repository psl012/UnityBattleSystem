using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleField : MonoBehaviour
{
    public BattlePlacement[] _battlePlacement;
    public PlayerBattlePlacement[] _playerBattlePlacement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeBattlePlacements()
    {
        _battlePlacement = GetComponentsInChildren<BattlePlacement>();
        _playerBattlePlacement = GetComponentsInChildren<PlayerBattlePlacement>();
        CreateBattlers();
    }

    void CreateBattlers()
    {
        foreach(BattlePlacement _bp in _battlePlacement)
        {
            _bp.CreateBattler();
        }
    }


}
