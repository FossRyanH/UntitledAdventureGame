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
    }

    public override void Update()
    {
        base.Update();

        if (!_enemy.PlayerDetection)
        {
            _enemy.ChangeState(_enemy.IdleState);
            return;
        }

        if (CheckTargetDistance())
        {
            _enemy.ChangeState(_enemy.AttackState);
            return;
        }
    }

    public override void PhysicsUpdate()
    {
        if (_enemy.PlayerDetection)
        {
            ChasePlayer();
            FacePlayer();
        }
    }

    public override void Exit()
    {
        base.Exit();
        _enemy.Agent.ResetPath();
    }

    void ChasePlayer()
    {
        if (_enemy.PlayerDetection)
        {
            if (_enemy.Agent.isOnNavMesh)
            {
                _enemy.Agent.destination = _player.transform.position;
                Move(_enemy.transform.forward * _enemy.TrashMobVars.MoveSpeed);
            }
        }

        _enemy.Agent.velocity = _enemy.Rb.velocity;
    }
}