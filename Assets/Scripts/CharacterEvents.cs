using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEvents : MonoBehaviour
{
    public event Action onNormalAttack = delegate{};    

    // Start is called before the first frame update
    public void NormalAttack()
    {
        onNormalAttack();
    }
}
