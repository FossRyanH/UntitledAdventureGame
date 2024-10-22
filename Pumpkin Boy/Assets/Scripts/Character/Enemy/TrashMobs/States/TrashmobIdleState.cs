using UnityEngine;
using System;

public class TrashmobIdleState : TrashmobBaseState
{
    public TrashmobIdleState(TrashMobMachine enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (_enemy.PlayerDetection)
        {
            _enemy.ChangeState(_enemy.ChaseState);
            return;
        }
    }
}