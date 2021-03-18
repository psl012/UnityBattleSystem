using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CharacterPanel))]
public class UICharacter : MonoBehaviour
{
    const string HP_TXT = "HP: ";
    const string MP_TXT = "MP: ";
    const string SP_TXT = "SP: ";

    CharacterPanel _characterPanel;
    Character _character;
    int _characterPanelNumber;
    [SerializeField] TextMeshProUGUI _hpText;
    [SerializeField] TextMeshProUGUI _mpText;
    [SerializeField] TextMeshProUGUI _specialText;
    
    void Awake()
    {

    }


    void Start()
    {
        _characterPanel = GetComponent<CharacterPanel>();
        _characterPanelNumber = _characterPanel._characterPanelNumber;
        _character = _characterPanel._myCharacter;
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
