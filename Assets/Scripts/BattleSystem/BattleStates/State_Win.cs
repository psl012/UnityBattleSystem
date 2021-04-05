using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Win : IState
{
    // Start is called before the first frame update
    public void Tick()
    {

    }

    public void OnEnter()
    {
        Debug.Log("WINNER WINNER CHICKEN DINNER!");
        GameManager.instance._characterDatabase.UpdateCharacterStats();
        GameManager.instance.ChangeScene();
    }

    public void OnExit()
    {
        
    }
}
