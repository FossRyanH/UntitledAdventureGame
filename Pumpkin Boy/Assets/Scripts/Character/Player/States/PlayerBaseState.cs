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
        _player.PlayerInputs.Attack += FireWeapon;
    }

    void DeregisterListeners()
    {
        _player.PlayerInputs.Movement -= Move;
        _player.PlayerInputs.Attack -= FireWeapon;
    }

    public void Move(Vector2 movement)
    {
        _player.InputDir = movement;
        _player.InputDir.Normalize();
    }

    public void Interact() {}

    public void FireWeapon()
    {
        MonoBehaviour.Instantiate(_player.BulletTrailPrefab, _player.GunPosition.position, _player.transform.rotation);
    }

    public void OpenMenu() {}

    protected void Movement(Vector3 movement)
    {
        _player.Rb.velocity = movement * Time.fixedDeltaTime;
    }

    protected void AimDirection()
    {
        var (success, position) = GetMousePos();

        if (success)
        {
            var direction = position - _player.transform.position;

            direction.y = 0f;
            
            _player.transform.forward = direction;
        }
    }

    private (bool success, Vector3 position) GetMousePos()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }
}