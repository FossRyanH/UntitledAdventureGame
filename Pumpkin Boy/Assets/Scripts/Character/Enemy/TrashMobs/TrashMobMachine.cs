using UnityEngine;
using System;

public class TrashMobMachine : Statemachine
{
    #region State
    public TrashmobIdleState IdleState;
    #endregion

    #region Components
    #endregion

    #region Misc
    public LayerMask PlayerLayer { get; set; }
    [field: SerializeField] public float DetectionRadius { get; private set; } = 5f;
    [field: SerializeField] public float DetectionAngle { get; private set; } = 60f;
    #endregion

    // Pass references to states here.
    public TrashMobMachine()
    {
        IdleState = new TrashmobIdleState(this);
    }

    void Awake()
    {
        PlayerLayer = LayerMask.GetMask("Player");
        Initialize(IdleState);
    }
}