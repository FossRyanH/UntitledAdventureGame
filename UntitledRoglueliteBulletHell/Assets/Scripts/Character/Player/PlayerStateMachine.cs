using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    #region Inputs
    [field: SerializeField] public PlayerControlChannelSO PlayerControls {get; private set; }
    #endregion

    #region Components
    public Rigidbody2D Rb2D { get; private set; }
    #endregion

    #region States
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    #endregion

    #region Misc
    public Vector2 InputDir { get; set; }
    #endregion

    public PlayerStateMachine()
    {
        IdleState = new PlayerIdleState(this);
    }

    void Awake()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        Initialize(IdleState);
    }
}
