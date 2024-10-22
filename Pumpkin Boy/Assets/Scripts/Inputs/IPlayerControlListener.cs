using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerControlListener
{
    void Move(Vector2 movement);
    void Interact();
    void FireWeapon();
    void OpenMenu();
}
