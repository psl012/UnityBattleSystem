using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    [SerializeField] CharacterAbilities _characterAbilities;

    [SerializeField] Target[] _targets;

    Character[] _enemies;    
    string _actionSelected;

    void Awake()
    {
        _enemies = FindObjectsOfType<Enemy>();
        AssignTarget();
    }

    // Start is called before the first frame update
    void Start()
    {
      //  _characterAbilities.AbilityDictionary[nameof(_characterAbilities.NormalAttack)](_enemies[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FightButton()
    {
        _actionSelected = nameof(_characterAbilities.NormalAttack);
    }


    public void TargetInteract(Target target)
    {
        if(target._targetCharacter == null) {return;}
        _characterAbilities.AbilityDictionary[_actionSelected](target._targetCharacter);
    }

    void AssignTarget()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _targets[i]._targetCharacter = _enemies[i];
        }
    }
}
