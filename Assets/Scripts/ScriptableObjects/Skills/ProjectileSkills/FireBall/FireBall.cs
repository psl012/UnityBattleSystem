using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D _rigidBody;
    List<Character> _listOftarget;
    List<int> _listOfIndex;
    bool _isCasted = false;
    bool _isFinishedMoving = false;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!_isCasted || _isFinishedMoving) 
        {
            return;
        }
        MoveToTarget();
   
    }

    public void Activate(List<Character> target, List<int> index)
    {
        _listOftarget = target;
        _listOfIndex = index;
        _isCasted = true;
    }

    public void MoveToTarget()
    {
        if(Vector2.Distance(transform.position, _listOftarget[_listOfIndex[0]].transform.position) < 0.05f)
        {
            Debug.Log("Moving finished");
            _isFinishedMoving = true;
        }

         transform.position = Vector2.MoveTowards(transform.position, _listOftarget[_listOfIndex[0]].transform.position, 5f*Time.deltaTime);
    }
}
