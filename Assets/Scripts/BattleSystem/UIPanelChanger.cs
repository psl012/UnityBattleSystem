using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelChanger : MonoBehaviour
{


    [SerializeField] GameObject _mainPanel;
    [SerializeField] GameObject _magicPanel;
    [SerializeField] GameObject _itemPanel;
    [SerializeField] GameObject _specialPanel;
    [SerializeField] GameObject _disablePanel;
    [SerializeField] GameObject _targetPanel;
 

    void Awake()
    {



    }

    void Start()
    {
        BattleEvents._battleEvents.onPlayerTurn += ActivateMainPanel;
        BattleEvents._battleEvents.onEnemyTurn += ActivateDisablePanel;

        BattleEvents._battleEvents.onFightButtonPress += ActivateTargetPanel;
    }

    public void ActivateMainPanel()
    {
        _mainPanel.SetActive(true);

        _magicPanel.SetActive(false);
        _itemPanel.SetActive(false);
        _specialPanel.SetActive(false);
        _targetPanel.SetActive(false);        
        _disablePanel.SetActive(false);
    }

    public void ActivateMagicPanel()
    {
        _magicPanel.SetActive(true);

        _mainPanel.SetActive(false);
        _itemPanel.SetActive(false);
        _specialPanel.SetActive(false);
        _targetPanel.SetActive(false);
        _disablePanel.SetActive(false);
    }
    public void ActivateItemPanel()
    {
        _itemPanel.SetActive(true);

        _mainPanel.SetActive(false);
        _magicPanel.SetActive(false);
        _specialPanel.SetActive(false);
        _targetPanel.SetActive(false);
        _disablePanel.SetActive(false);
    }

    public void ActivateSpecialPanel()
    {
        _specialPanel.SetActive(true);

        _itemPanel.SetActive(false);
        _mainPanel.SetActive(false);
        _magicPanel.SetActive(false);
        _targetPanel.SetActive(false);
        _disablePanel.SetActive(false);
    }

    public void ActivateDisablePanel()
    {
        _disablePanel.SetActive(true);

        _mainPanel.SetActive(false);
        _magicPanel.SetActive(false);
        _itemPanel.SetActive(false);
        _specialPanel.SetActive(false);
        _targetPanel.SetActive(false);
    }


    public void ActivateTargetPanel()
    {
        _targetPanel.SetActive(true);

        _mainPanel.SetActive(false);
        _magicPanel.SetActive(false);
        _itemPanel.SetActive(false);
        _specialPanel.SetActive(false);
        _disablePanel.SetActive(false);
    }

    void OnDestroy()
    {
        BattleEvents._battleEvents.onPlayerTurn -= ActivateMainPanel;
        BattleEvents._battleEvents.onEnemyTurn -= ActivateDisablePanel;
        BattleEvents._battleEvents.onFightButtonPress -= ActivateTargetPanel;
    }

}

