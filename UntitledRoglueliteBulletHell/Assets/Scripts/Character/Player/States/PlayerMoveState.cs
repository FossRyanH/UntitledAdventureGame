using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    float _moveSpeed;

    public PlayerMoveState(PlayerStateMachine player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"{_player.name} is a moving");
        _moveSpeed = _player.playerVariables.WalkSpeed;
    }

    public override void Update()
    {
        if (_player.InputDir == Vector2.zero)
        {
            _player.ChangeState(_player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        _player.Rb2D.velocity = _player.InputDir * _moveSpeed * Time.fixedDeltaTime;
    }
}