using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : Statemachine
{
    #region InputSO's
    [field: SerializeField] public PlayerControlChannelSO PlayerInputs { get; private set; }
    #endregion
    
    #region Components
    public Rigidbody Rb { get; private set; }
    [field: SerializeField] public PlayerVariablesSO PlayerVariables { get; private set; }
    [field:SerializeField] public Transform GunPosition { get; set; }
    [field: SerializeField] public GameObject BulletTrailPrefab { get; set; }
    #endregion
    
    #region States
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    #endregion
    
    #region Misc
    public Vector2 InputDir { get; set; }
    public Vector2 MouseDir { get; set; }
    #endregion

    public PlayerController()
    {
        IdleState = new PlayerIdleState(this);
        MoveState = new PlayerMoveState(this);
    }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Initialize(IdleState);
    }

    protected override void Update() { base.Update(); }
    
    protected override void FixedUpdate() { base.FixedUpdate(); }
}
