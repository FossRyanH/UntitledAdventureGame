using System;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Inputs/PlayerControlChannel", fileName = "PlayerControlChannel", order = 0)]
public class PlayerControlChannelSO : ScriptableObject
{
    public event Action<Vector2> Movement;
    public event Action Interact, Attack, OpenInventory, OpenMenu;
    public event Action<bool> Dodge, HeavyAttack;

    public void HandleMovement(Vector2 movement) => Movement?.Invoke(movement);
    public void HandleInteract() => Interact?.Invoke();
    public void HandleAttack() => Attack?.Invoke();
}