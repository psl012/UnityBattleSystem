using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootExpManager : MonoBehaviour
{
    public float _expPoints;
    CharacterLevelManager _characterLevelManager;
    bool hasDropLoot = false;

    void Awake()
    {
        _characterLevelManager = GetComponent<CharacterLevelManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropExpLoot()
    {
        if(!hasDropLoot)
        {
            GameManager.instance._characterDatabase.IncreasePartyExpPoints(50);
            hasDropLoot = true;
        }
    }
}
