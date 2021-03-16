using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanelManager : MonoBehaviour
{
    [SerializeField] CharacterPanel[] _characterPanels;

    public void ActivateCharacterPanel(int panelNumber)
    {
        for(int i = 0; i < _characterPanels.Length; i++)
        {
            if(i == panelNumber)
            {
                _characterPanels[i].gameObject.SetActive(true);
            }
            else
            {
                _characterPanels[i].gameObject.SetActive(false);
            }
        }
    }
}
