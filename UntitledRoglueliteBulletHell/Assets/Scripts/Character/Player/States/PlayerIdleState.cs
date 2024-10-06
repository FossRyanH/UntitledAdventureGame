using UnityEngine;
using System;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"{_player.name} is Idling");
    }

    public override void Update()
    {
        if (_player.InputDir != Vector2.zero)
        {
            _player.ChangeState(_player.MoveState);
        }
    }
}