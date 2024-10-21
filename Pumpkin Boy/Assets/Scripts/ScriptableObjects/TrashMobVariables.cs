using UnityEngine;
using System;

[CreateAssetMenu(menuName = "SO/Mobs/TrashmobVariables", fileName = "TrashmobVariables", order = 0)]
public class TrashMobVariables : ScriptableObject
{
    [field: SerializeField] public float MoveSpeed { get; set; }
    [field: SerializeField] public float AttackCooldown { get; set; }
}