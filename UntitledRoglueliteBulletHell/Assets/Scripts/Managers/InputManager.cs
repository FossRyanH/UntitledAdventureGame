using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    #region SO Inputs
    [SerializeField] PlayerControlChannelSO playerControlChannel;
    #endregion

    #region Inputs & Actions
    private GameInputs _gameInput;
    private GameInputType _gameInputType;
    private Dictionary<GameInputType, InputActionMap> _actionMaps;
    #endregion

    protected override void Initialize()
    {
        if (_actionMaps == null)
            _actionMaps = new Dictionary<GameInputType, InputActionMap>();
        
        if (_gameInput == null)
        {
            _gameInput = new GameInputs();
            #region Player Controls
            _gameInput.Player.Move.performed += (ctx) => playerControlChannel.HandleMovement(ctx.ReadValue<Vector2>());
            _actionMaps.Add(GameInputType.Player, _gameInput.Player);
            #endregion
            #region Inventory Controls
            #endregion
            #region Menu Controls
            #endregion
        }
        _gameInput.Enable();
    }

    public void EnableInputType(GameInputType inputType)
    {
        _actionMaps[inputType].Enable();
    }

    public void DisableInputs(GameInputType inputType)
    {
        _actionMaps[inputType].Disable();
    }
}

public enum GameInputType { Player, Inventory, Menu }
