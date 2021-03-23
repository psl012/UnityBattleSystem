using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    [SerializeField] GameObject _actionCamera;

    public void SetActionCameraOn()
    {
        _actionCamera.SetActive(true);
    }

    public void SetActionCameraOff()
    {
        _actionCamera.SetActive(false);
    }
    
}
