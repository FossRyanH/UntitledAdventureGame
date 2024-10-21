using UnityEngine;
using System;

public class TrashmobChaseState : TrashmobBaseState
{
    public TrashmobChaseState(TrashMobMachine enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"{_enemy.gameObject.name} is Chasing Player");
    }

    public override void Update()
    {
        base.Update();

        if (!_enemy.PlayerDetection)
        {
            _enemy.ChangeState(_enemy.IdleState);
            return;
        }

        if (CheckTargetDistance() && !_enemy.IsAttacking)
        {
            _enemy.ChangeState(_enemy.AttackState);
            return;
        }
    }

    public override void PhysicsUpdate()
    {
        if (_enemy.PlayerDetection)
        {
            Move(_enemy.transform.forward * _enemy.TrashMobVars.MoveSpeed);
            FacePlayer();
        }
    }
}