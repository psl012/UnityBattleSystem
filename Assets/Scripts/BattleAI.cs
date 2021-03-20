using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAI : MonoBehaviour
{
    Character _character;
    CharacterAbilities _characterAbilities;

    BattlePlacement[] _allyTargets;
    BattlePlacement[] _enemyTargets;
    
    BattleSystem _battleSystem;

    BattleField _battleField;

    TargetManager _targetManager;
    TargetIcon _targetIcon;

    float _attackPower;

    private void Awake()
    {
        _character = GetComponent<Character>();
        _characterAbilities = GetComponent<CharacterAbilities>();
        _battleField = FindObjectOfType<BattleField>();
        _targetIcon = FindObjectOfType<TargetIcon>();
        _battleSystem = FindObjectOfType<BattleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _attackPower = _character._attackPower;
        FindTargets();
        _targetManager = new TargetManager(_allyTargets, _battleField._playerBattlePlacement, _characterAbilities, _targetIcon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DefaultAttack()
    {
        FightButton();
        TargetInteractButton();
    }

    void FindTargets()
    {
        if(tag=="Enemy")
        {
            _allyTargets = FindObjectsOfType<EnemyBattlePlacement>();
            _enemyTargets = FindObjectsOfType<PlayerBattlePlacement>();
        }
        else
        {
            _allyTargets = FindObjectsOfType<PlayerBattlePlacement>();
            _enemyTargets = FindObjectsOfType<EnemyBattlePlacement>();    
        }
    }

    public virtual void FightButton()
    {
        _targetManager.SetAbility(DictionarySkillKeys.SKILL_0, BattleEnums.TargetType.Enemy);
        //_battleSystem.TargetMode();
    }

    public void ChangeTargetButton(string direction)
    {
        _targetManager.ChangeTarget(direction);
    }

    public void TargetInteractButton()
    {
        _targetManager.TargetInteract();
        /**if (_targetManager.TargetInteract())
        {
            //_uiPanelChanger.ActivateMainPanel();
            // _uiPanelChanger.ActivateDisablePanel();
        }*/
    }


}
