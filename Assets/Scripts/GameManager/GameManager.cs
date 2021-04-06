using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set;}
    public CharacterDatabase _characterDatabase;
    BattleSystem _battleSystem;
    int currentSceneIndex;
    int numberOfScenesInTheBuild;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            numberOfScenesInTheBuild = SceneManager.sceneCountInBuildSettings;
            _characterDatabase = GetComponentInChildren<CharacterDatabase>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        _battleSystem = FindObjectOfType<BattleSystem>();
        _battleSystem.InitializeBattleSystem();
        _characterDatabase.UpdateBattlerCharacterStats();
      //  Debug.Log(_characterDatabase._partyMembersObjects[0].GetComponent<Character>()._characterStats._attackPower);
    //    Debug.Log("Let see: " + _characterDatabase._partyMembersObjects[0].name);
     //   Debug.Log("Lets see: " + _characterDatabase._partyMembersObjects[0].GetComponent<Character>()._characterHPMPManager._currentHP);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        if(currentSceneIndex < numberOfScenesInTheBuild - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
