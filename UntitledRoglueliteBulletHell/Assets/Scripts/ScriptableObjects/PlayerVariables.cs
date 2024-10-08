using UnityEngine;
using System;

[CreateAssetMenu(menuName = "SO/PlayerVariables", fileName = "PlayerVariables", order = 0)]
public class PlayerVariables : ScriptableObject
{
    #region Movement Variables
    [field: SerializeField] public float WalkSpeed { get; set; }
    [field: SerializeField] public float DashSpeed { get; set; }
    #endregion
}