using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MagicPanelManager : MonoBehaviour
{
    TextMeshProUGUI[] _spellTextName;
    // Start is called before the first frame update
    
    void Awake()
    {

    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeMagicPanels(Skill[] skills)
    {
        _spellTextName = GetComponentsInChildren<TextMeshProUGUI>();
        
        for(int i = 1; i < skills.Length; i++)
        {
            if(skills[i] != null)
            {
                _spellTextName[i-1].text = skills[i]._skillName;
            }
        }
    }
}
