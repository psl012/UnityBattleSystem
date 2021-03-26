using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CharacterCamera : MonoBehaviour
{
    [SerializeField] GameObject _actionCamera;
    [SerializeField] CinemachineVirtualCamera  _idleVirtualCam;

    public void SetIdleCamFollow(Transform lockTarget)
    {
        _idleVirtualCam.Follow = lockTarget;
    }

    public void SetActionCameraOn()
    {
        _actionCamera.SetActive(true);
    }

    public void SetActionCameraOff()
    {
        _actionCamera.SetActive(false);
    }
    
}
