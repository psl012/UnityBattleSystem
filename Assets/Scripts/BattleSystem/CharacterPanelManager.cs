﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanelManager : MonoBehaviour
{
    [SerializeField] CharacterPanel[] _characterPanels;

    [SerializeField] GameObject _neutralPanel;

    public void ActivateCharacterPanel(int panelNumber)
    {
        for(int i = 0; i < _characterPanels.Length; i++)
        {
            if(i == panelNumber)
            {
                _characterPanels[i].gameObject.SetActive(true);
                _characterPanels[i].TriggerCharacterIcon(true);
            }
            else
            {
                _characterPanels[i].TriggerCharacterIcon(false);
                _characterPanels[i].gameObject.SetActive(false);
            }
        }
        _neutralPanel.SetActive(false);
    }

    public void ActivateNeutralPanel()
    {
        foreach(CharacterPanel panel in _characterPanels)
        {
            panel.gameObject.SetActive(false);
        }
        _neutralPanel.SetActive(true);
    }
}