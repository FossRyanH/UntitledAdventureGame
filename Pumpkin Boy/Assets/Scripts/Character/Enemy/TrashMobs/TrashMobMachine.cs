using UnityEngine;
using System;
using UnityEngine.AI;

public class TrashMobMachine : Statemachine
{
    #region State
    public TrashmobIdleState IdleState { get; private set; }
    public TrashmobChaseState ChaseState { get; private set; }
    public TrashmobAttackState AttackState { get; private set; }

    #endregion

    #region Components
    [field: SerializeField] public TrashMobVariables TrashMobVars { get; set; }
    public Rigidbody Rb { get; private set; }
    public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public Transform ProjectilePoint { get; private set; }
    [field: SerializeField] public GameObject BulletPrefab { get; private set; }
    #endregion

    #region Misc
    public LayerMask PlayerLayer { get; set; }
    // from here
    [field: SerializeField] public float DetectionRadius { get; private set; } = 5f;
    [field: SerializeField] public float DetectionAngle { get; private set; } = 60f;
    // To here move to the variable script
    public bool IsAttacking { get; set; } = false;
    public bool PlayerDetection { get; set; } = false;
    #endregion

    // Pass references to states here.
    public TrashMobMachine()
    {
        IdleState = new TrashmobIdleState(this);
        ChaseState =  new TrashmobChaseState(this);
        AttackState =  new TrashmobAttackState(this);
    }

    void Awake()
    {
        PlayerLayer = LayerMask.GetMask("Player");
        Rb = GetComponent<Rigidbody>();
        Agent = GetComponent<NavMeshAgent>();
        Initialize(IdleState);
    }
}