using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    TargetManager _targetManager;
    [SerializeField] Character _characterOwner;
    [SerializeField] CharacterAbilities _characterAbilities;
    Character[] _playerTargetChars;
    Character[] _enemyTargetChars;


    void Awake()
    {
        _playerTargetChars = FindObjectsOfType<Player>();
        _enemyTargetChars = FindObjectsOfType<Enemy>();

        _targetManager = new TargetManager(_playerTargetChars, _enemyTargetChars, _characterAbilities);
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FightButton()
    {
        _targetManager.SetAbility(nameof(_characterAbilities.NormalAttack), BattleEnums.TargetType.Enemy);
        BattleEvents._battleEvents.FightButtonPress();
    }

    public void ChangeTargetButton(string direction)
    {
        _targetManager.ChangeTarget(direction);
    }

    public void TargetInteractButton()
    {
        _targetManager.TargetInteract();
    }
}
