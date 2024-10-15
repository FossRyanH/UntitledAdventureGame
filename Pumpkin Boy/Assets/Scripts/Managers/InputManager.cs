using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    #region Input SO's
    [SerializeField] private PlayerControlChannelSO playerControlChannel;
    #endregion
    
    #region Input Variables
    GameInputs _gameInputs;
    private GameInputType _gameInputType;
    Dictionary<GameInputType, InputActionMap> _actionMaps;
    #endregion
    
    protected override void Init()
    {
        if (_actionMaps == null)
        {
            _actionMaps = new Dictionary<GameInputType, InputActionMap>();
        }

        if (_gameInputs == null)
        {
            _gameInputs = new GameInputs();
            #region Player Inputs
            _gameInputs.Player.Move.performed += (ctx) => playerControlChannel.HandleMovement(ctx.ReadValue<Vector2>());
            #endregion
        }
        _gameInputs.Enable();
    }
}

public enum GameInputType { Player, Menu }
