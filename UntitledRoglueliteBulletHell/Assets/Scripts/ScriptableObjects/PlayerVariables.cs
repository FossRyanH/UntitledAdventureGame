using UnityEngine;
using System;

[CreateAssetMenu(menuName = "SO/PlayerVariables", fileName = "PlayerVariables", order = 0)]
public class PlayerVariables : ScriptableObject
{
    [Header("Movement Variables")]
    [field: SerializeField] float WalkSpeed { get; set; }
    [field: SerializeField] float DashSpeed { get; set; }
}