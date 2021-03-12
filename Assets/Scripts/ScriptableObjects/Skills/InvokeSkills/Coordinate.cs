using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate : Invocation
{
    public override void Activate(CharacterAbilities user, List<Character> target, List<int> index)
    {
        base.Activate(user, target, index);
        transform.position = target[index[0]].transform.position;
    }
}
