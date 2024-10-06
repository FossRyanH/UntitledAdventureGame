using UnityEngine;
using System;

public class PlayerBaseState : IState, IPlayerControlListener
{
    protected PlayerStateMachine _player;

    public PlayerBaseState(PlayerStateMachine player)
    {
        _player = player;
    }

    public void Attack() {}

    public virtual void Enter() 
    {
        RegisterListeners();
    }
    
    public virtual void Exit() 
    {
        DeregisterListeners();
    }

    public void Interact() {}

    public void Move(Vector2 movement)
    {
        _player.InputDir = movement;
        _player.InputDir.Normalize();
    }

    public void OpenInvenotry() {}

    public virtual void PhysicsUpdate() {}

    public void SwapWeapon() {}

    public virtual void Update() {}

    void RegisterListeners()
    {
        _player.PlayerControls.OnMove += Move;
    }

    void DeregisterListeners()
    {
        _player.PlayerControls.OnMove -= Move;
    }
}