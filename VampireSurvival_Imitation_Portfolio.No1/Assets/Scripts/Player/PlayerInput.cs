using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool IsUp { get; private set; }
    public bool IsDown { get; private set; }
    public bool IsRight { get; private set; }
    public bool IsLeft { get; private set; }
    public bool IsNext { get; private set; }
    public bool IsBack { get; private set; }
    public bool IsReturn { get; private set; }

    private void Update()
    {
        IsUp = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
        IsDown = Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S);
        IsRight = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);
        IsLeft = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A);
        IsNext = Input.GetKeyDown(KeyCode.Space);
        IsBack = Input.GetKeyDown(KeyCode.Escape);
        IsReturn = Input.GetKeyDown(KeyCode.Backspace);
    }
}
