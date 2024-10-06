using UnityEngine;

public interface IPlayerControlListener
{
    void Move(Vector2 movement);
    void Interact();
    void Attack();
    void SwapWeapon();
    void OpenInvenotry();
}