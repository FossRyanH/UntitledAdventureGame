using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        AimDirection();
        
        if (_player.InputDir.magnitude > 0.1f)
        {
            _player.ChangeState(_player.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        
    }
}
