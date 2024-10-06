using System;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public IState CurrentState { get; private set; }

    public event Action<IState> OnStateChanged;

    // Set the initial State of the character.
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

    protected virtual void FixedUpdate()
    {
        CurrentState.PhysicsUpdate();
    }
}
