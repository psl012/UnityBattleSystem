using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Lose : IState
{
    // Start is called before the first frame update
    public void Tick()
    {

    }

    public void OnEnter()
    {
        Debug.Log("LOOOSER");
    }

    public void OnExit()
    {
        
    }
}
