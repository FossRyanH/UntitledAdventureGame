using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerBaseState : IState, IPlayerControlListener
{
    protected PlayerController _player;

    public PlayerBaseState(PlayerController player)
    {
        _player = player;
    }

    public virtual void Enter()
    {
        RegisterListeners();
    }

    public virtual void Update() {}

    public virtual void PhysicsUpdate() {}

    public virtual void Exit()
    {
        DeregisterListeners();
    }

    void RegisterListeners()
    {
        _player.PlayerInputs.Movement += Move;
    }

    void DeregisterListeners()
    {
        _player.PlayerInputs.Movement -= Move;
    }

    public void Move(Vector2 movement)
    {
        _player.InputDir = movement;
        _player.InputDir.Normalize();
    }

    public void Interact() {}

    public void FireWeapon() {}

    public void OpenMenu() {}

    protected void Movement(Vector3 movement)
    {
        _player.Rb.velocity = movement * Time.fixedDeltaTime;
    }

    protected void FaceDirection(Vector3 inputDirection)
    {
        if (inputDirection.magnitude > Mathf.Epsilon)
        {
            _player.transform.rotation = Quaternion.Lerp(_player.transform.rotation, Quaternion.LookRotation(inputDirection), 10f * Time.fixedDeltaTime);
        }
    }
}