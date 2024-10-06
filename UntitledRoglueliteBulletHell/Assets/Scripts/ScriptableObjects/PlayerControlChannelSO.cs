using System;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerControlChannelSO/Inputs/PlayerControls", fileName = "PlayerControlChannel", order = 0)]
public class PlayerControlChannelSO : ScriptableObject
{
    public event Action<Vector2> OnMove;
    public event Action OnInteract, OnAttack, OnWeaponSwap, OnOpenInventory;

    public void HandleMovement(Vector2 movement) => OnMove?.Invoke(movement);
    public void HandleInteraction() => OnInteract?.Invoke();
    public void HandleAttack() => OnAttack?.Invoke();
    public void HandleWeaponSwap() => OnWeaponSwap?.Invoke();
    public void HandleOpenInventory() => OnOpenInventory?.Invoke();
}