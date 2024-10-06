using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateMachine player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"{_player.name} is a moving");
    }
}