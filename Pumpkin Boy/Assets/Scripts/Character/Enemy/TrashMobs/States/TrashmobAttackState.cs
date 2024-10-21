using UnityEngine;
using System;
using System.Collections;

public class TrashmobAttackState : TrashmobBaseState
{
    public TrashmobAttackState(TrashMobMachine enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.IsAttacking = true;
        _enemy.StartCoroutine(AttackPlayer());
    }

    public override void PhysicsUpdate()
    {
        if (_enemy.PlayerDetection && CheckTargetDistance())
        {
            FacePlayer();
        }
    }

    public override void Update()
    {
        base.Update();
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
        yield return new WaitForSeconds(_enemy.TrashMobVars.AttackCooldown);
        MonoBehaviour.Instantiate(_enemy.BulletPrefab, _enemy.ProjectilePoint.position, _enemy.transform.rotation);
        _enemy.ChangeState(_enemy.IdleState);
    }
}