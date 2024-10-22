using UnityEngine;
using System;
using System.Collections;

public class TrashmobAttackState : TrashmobBaseState
{
    float _timer;
    public TrashmobAttackState(TrashMobMachine enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.IsAttacking = true;
        _timer = _enemy.TrashMobVars.AttackCooldown;        
    }

    public override void PhysicsUpdate()
    {
        if (_timer <= 0)
        {
            _enemy.StartCoroutine(AttackPlayer());
        }
        
        if (_enemy.PlayerDetection && CheckTargetDistance())
        {
            FacePlayer();
        }
    }

    public override void Update()
    {
        base.Update();

        _timer -= Time.fixedDeltaTime;

        if (!CheckTargetDistance())
        {
            _enemy.ChangeState(_enemy.IdleState);
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
        _enemy.IsAttacking = false;
    }

    IEnumerator AttackPlayer()
    {
        MonoBehaviour.Instantiate(_enemy.BulletPrefab, _enemy.ProjectilePoint.position, _enemy.transform.rotation);
        _timer = _enemy.TrashMobVars.AttackCooldown;
        yield return null;
    }
}