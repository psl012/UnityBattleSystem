using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBall : Projectile
{
    protected bool _hasProcDamage = false;
    protected float _initialDistance; 

    [SerializeField] float lifeAfterDamageProc;
   
    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(!_isCasted) 
        {
            return;
        }
        MoveToTarget();
    }

    public override void Activate(CharacterStats userStats, CharacterBattleAnimator userAnimator, Character target)
    {
        base.Activate(userStats, userAnimator, target);
        _initialDistance = transform.position.x - target.transform.position.x;

    }

    public override void MoveToTarget()
    {
        if(CheckXCollision() && !_hasProcDamage)
        {
            DamageTarget();
            _hasProcDamage = true;
            PlayDeathAnimationIfDead();
            TriggerEndTurn();
            StartCoroutine(EndTurnTimer());
        }
        transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
    }

    public override void DamageTarget()
    {
        base.DamageTarget();
    }

    public IEnumerator EndTurnTimer()
    {
        yield return new WaitForSeconds(lifeAfterDamageProc);
        Destroy(gameObject);
    }

    bool CheckXCollision()
    {
        float currentDistance = transform.position.x - _target.transform.position.x;
        if(Mathf.Sign(_initialDistance)*Mathf.Sign(currentDistance) < 0.05f)
        {
            return true;
        }
        return false;
    }
}
