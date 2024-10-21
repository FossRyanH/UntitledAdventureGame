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
        Debug.Log($"{_enemy.gameObject.name} is Idling");
    }

    public override void Update()
    {
        DetectPlayer();
        FacePlayer();
    }
}