using UnityEngine;
using System;

public class TrashMobMachine : Statemachine
{
    #region State
    public TrashmobIdleState IdleState;
    public TrashmobChaseState ChaseState;
    #endregion

    #region Components
    [field: SerializeField] public TrashMobVariables TrashMobVars { get; set; }
    public Rigidbody Rb { get; private set; }
    #endregion

    #region Misc
    public LayerMask PlayerLayer { get; set; }
    [field: SerializeField] public float DetectionRadius { get; private set; } = 5f;
    [field: SerializeField] public float DetectionAngle { get; private set; } = 60f;
    public bool PlayerDetection { get; set; } = false;
    #endregion

    // Pass references to states here.
    public TrashMobMachine()
    {
        IdleState = new TrashmobIdleState(this);
        ChaseState =  new TrashmobChaseState(this);
    }

    void Awake()
    {
        PlayerLayer = LayerMask.GetMask("Player");
        Rb = GetComponent<Rigidbody>();
        Initialize(IdleState);
    }
}