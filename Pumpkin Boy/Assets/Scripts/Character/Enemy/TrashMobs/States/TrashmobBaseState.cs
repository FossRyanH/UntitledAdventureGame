using System;
using UnityEngine;

public class TrashmobBaseState : IState

{
    protected TrashMobMachine _enemy;
    protected GameObject _player;

    public TrashmobBaseState(TrashMobMachine enemy)
    {
        _enemy = enemy;
    }

    public virtual void Enter() 
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public virtual void PhysicsUpdate() {}

    public virtual void Update() 
    {
        _enemy.PlayerDetection = DetectPlayer();
        DetectPlayer();
    }

    public virtual void Exit() {}

    protected bool DetectPlayer()
    {
        Vector3 forward = _enemy.transform.forward;
        float halfAngle = _enemy.DetectionAngle / 2f;

        int numOfRays = 20;

        Ray[] rays = new Ray[numOfRays];

        for (int i = 0; i < numOfRays; i++)
        {
            float angleOffSet = (i / (float)(numOfRays - 1)) * halfAngle;
            Vector3 direction = Quaternion.Euler(0, angleOffSet, 0) * forward;
            rays[i] = new Ray(_enemy.transform.position, direction);
        }

        foreach (Ray ray in rays)
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _enemy.DetectionRadius, _enemy.PlayerLayer))
            {
                Debug.Log($"{hit.collider.gameObject.name} was hit!");
                return true;
            }
        }

        return false;
    }

    protected void FacePlayer()
    {
        if (DetectPlayer())
        {
            Vector3 playerDir = _player.transform.position - _enemy.transform.position;
            float angle = Vector3.Angle(_enemy.transform.forward, playerDir);

            if (angle <= _enemy.DetectionAngle / 2f)
            {
                Vector3 targetDir = _player.transform.position - _enemy.transform.position;
                targetDir.y = 0f;
                Quaternion rotation = Quaternion.LookRotation(targetDir);
                _enemy.transform.rotation = Quaternion.Slerp(_enemy.transform.rotation, rotation, 10f * Time.fixedDeltaTime);
            }
        }
    }

    protected void Move(Vector3 movement)
    {
        _enemy.Rb.velocity = movement * Time.fixedDeltaTime;
    }
}