using UnityEngine;

public class TrashmobBaseState : IState

{
    protected TrashMobMachine _enemy;
    protected GameObject _player;

    public TrashmobBaseState(TrashMobMachine enemy)
    {
        _enemy = enemy;
    }

    public virtual void Enter() {}

    public virtual void PhysicsUpdate() {}

    public virtual void Update() {}

    public virtual void Exit() {}

    protected bool DetectPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(_enemy.transform.position, _enemy.DetectionRadius, _enemy.PlayerLayer);

        _player = GameObject.FindGameObjectWithTag("Player");

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Player"))
            {
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
}