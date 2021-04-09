using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set;}
    public CharacterDatabase _characterDatabase;
    BattleField _battleField;
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
        _battleField = FindObjectOfType<BattleField>();
        _battleSystem = FindObjectOfType<BattleSystem>();

        _battleField.SetupBattleField(_characterDatabase._partyMembersObjects, _characterDatabase._enemyObjects);
        _characterDatabase.UpdatePartyCharacters(_battleField._playerCharacters);
        _battleSystem.InitializeBattleSystem();
        
        _characterDatabase.UpdateBattlerCharacterStats();
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
