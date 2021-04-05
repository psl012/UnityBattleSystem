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
    CharacterStats _characterStats;

    int _characterPanelNumber;
    [SerializeField] TextMeshProUGUI _hpText;
    [SerializeField] TextMeshProUGUI _mpText;
    [SerializeField] TextMeshProUGUI _specialText;
    
    void Awake()
    {

    }


    void Start()
    {

    }

    public void InitializeUI()
    {
        _characterPanel = GetComponent<CharacterPanel>();
        _characterPanelNumber = _characterPanel._characterPanelNumber;
        if (_characterPanel._myCharacter == null) return;
        _characterStats = _characterPanel._myCharacter._characterStats;
        _characterPanel._myCharacter.GetComponent<CharacterHPMPManager>()?.InitializeUICharacter(this);
        
        UpdateHPText(_characterStats._maxHealth);  // Cannot put in Awake (It is where we assing max health) 
        UpdateMPText(_characterStats._maxMana);
        UpdateSpecialText();
    }

    public void UpdateHPText(float currentHealth)
    {
         _hpText.text = UpdateCharacterTextUI(HP_TXT, currentHealth, _characterStats._maxHealth);
    }

    public void UpdateMPText(float currentMana)
    {
        _mpText.text = UpdateCharacterTextUI(MP_TXT, currentMana, _characterStats._maxMana);
    }

    public void UpdateSpecialText()
    {
        _specialText.text = UpdateCharacterTextUI(SP_TXT, _characterStats._specialPoints, 100);
    }

    public string UpdateCharacterTextUI(string txt1, float currentValue, float maxValue)
    {
        return txt1 + currentValue.ToString() + "/" + maxValue.ToString();
    }

}
