using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerVariables", fileName = "PlayerVariables", order = 0)]
public class PlayerVariablesSO : ScriptableObject
{
    [field: SerializeField] public float MovementSpeed { get; set; }
    [field: SerializeField] public float DashSpeed { get; set; }
}
