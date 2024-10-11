using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statemachine : MonoBehaviour
{
    public IState CurrentState { get; private set; }

    public event Action<IState> OnStateChanged;

    protected void Initialize(IState firstState)
    {
        if (CurrentState != null) { return; }
        CurrentState = firstState;
        firstState.Enter();

        OnStateChanged?.Invoke(firstState);
    }

    public void ChangeState(IState nextState)
    {
        if (CurrentState == null) { return; }
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();

        OnStateChanged?.Invoke(nextState);
    }

    protected virtual void Update()
    {
        CurrentState.Update();
    }

    protected void FixedUpdate()
    {
        CurrentState.PhysicsUpdate();
    }
}
