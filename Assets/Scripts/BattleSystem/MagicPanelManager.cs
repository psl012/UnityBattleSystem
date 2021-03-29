using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MagicPanelManager : MonoBehaviour
{
    TextMeshProUGUI[] _spellTextName;
    [SerializeField] TextMeshProUGUI _lackManaText;

    bool isCoroutineRunning = false;
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

    public void DisplayLackManaText()
    {
        if(isCoroutineRunning)
        {
            return;
        }
        else
        {
            isCoroutineRunning = true;
            StartCoroutine(CoroutineDisplayLackManaText());
        }
    }

    public IEnumerator CoroutineDisplayLackManaText()
    {
        float timer = 2;

        _lackManaText.text = "Not enough Mana!";    
         yield return new WaitForSeconds(timer);
        _lackManaText.text = "";
        isCoroutineRunning = false;
    }
}
