using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICharacter : MonoBehaviour
{
    const string HP_TXT = "HP: ";
    const string MP_TXT = "MP: ";
    const string SP_TXT = "SP: ";

    Character _character;
    [SerializeField] int _characterPanelNumber;
    [SerializeField] TextMeshProUGUI _hpText;
    [SerializeField] TextMeshProUGUI _mpText;
    [SerializeField] TextMeshProUGUI _specialText;
    
    void Awake()
    {
        InitializeCharacterPanel();
    }

    public void InitializeCharacterPanel()
    {
        Character[] players = FindObjectsOfType<Character>();
        foreach(Character ch in players)
        {
            if(ch._battlePosition == _characterPanelNumber)
            {
                _character = ch;
            }
        }
    }

    void Start()
    {
        UpdateHPText();  // Cannot put in Awake (It is where we assing max health) 
        UpdateMPText();
        UpdateSpecialText();
    }

    void UpdateHPText()
    {
         _hpText.text = UpdateCharacterTextUI(HP_TXT, _character._health, _character._maxHealth);
    }

    void UpdateMPText()
    {
        _mpText.text = UpdateCharacterTextUI(MP_TXT, _character._mana, _character._maxMana);
    }

    void UpdateSpecialText()
    {
        _specialText.text = UpdateCharacterTextUI(SP_TXT, _character._specialPoints, 100);
    }

    string UpdateCharacterTextUI(string txt1, float currentValue, float maxValue)
    {
        return txt1 + currentValue.ToString() + "/" + maxValue.ToString();
    }

}
