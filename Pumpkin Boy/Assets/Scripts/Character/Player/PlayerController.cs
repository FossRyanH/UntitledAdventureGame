using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Statemachine
{
    #region InputSO's
    [field: SerializeField] public PlayerControlChannelSO PlayerInputs { get; private set; }
    #endregion
}
