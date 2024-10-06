using UnityEngine;
using System;

public class PlayerBaseState : IState, IPlayerControlListener
{
    protected PlayerStateMachine _player;

    public PlayerBaseState(PlayerStateMachine player)
    {
        _player = player;
    }

    public virtual void Enter() {}
    public virtual void Exit() {}

    public void Move(Vector2 movement)
    {
        _player.InputDir = movement;
        _player.InputDir.Normalize();
    }

    public virtual void PhysicsUpdate() {}
    public virtual void Update() {}
}