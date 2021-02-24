using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelChanger : MonoBehaviour
{
    [SerializeField] GameObject _mainPanel;
    [SerializeField] GameObject _magicPanel;
    [SerializeField] GameObject _itemPanel;
    [SerializeField] GameObject _specialPanel;
 
    void Start()
    {
        ActivateMainPanel();
    }

    public void ActivateMainPanel()
    {
        _mainPanel.SetActive(true);
        _magicPanel.SetActive(false);
        _itemPanel.SetActive(false);
        _specialPanel.SetActive(false);
    }

    public void ActivateMagicPanel()
    {
        _magicPanel.SetActive(true);
        _mainPanel.SetActive(false);
        _itemPanel.SetActive(false);
        _specialPanel.SetActive(false);
    }
    public void ActivateItemPanel()
    {
        _itemPanel.SetActive(true);
        _mainPanel.SetActive(false);
        _magicPanel.SetActive(false);
        _specialPanel.SetActive(false);
    }

    public void ActivateSpecialPanel()
    {
        _specialPanel.SetActive(true);
        _itemPanel.SetActive(false);
        _mainPanel.SetActive(false);
        _magicPanel.SetActive(false);   
    }

}

