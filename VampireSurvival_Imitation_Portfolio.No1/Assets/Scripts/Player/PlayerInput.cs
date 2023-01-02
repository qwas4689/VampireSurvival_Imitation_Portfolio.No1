using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputKind = Define.EPlayerInput;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputKind _inputKind;

    public bool IsUp { get; private set; }
    public bool IsDown { get; private set; }
    public bool IsRight { get; private set; }
    public bool IsLeft { get; private set; }
    public bool IsNext { get; private set; }
    public bool IsBack { get; private set; }
    public bool IsReturn { get; private set; }

    private const string Z_DIR = "Horizontal";
    private const string X_DIR = "Vertical";
    private Vector3 _move;
    public Vector3 Move { get { return _move; } private set { _move = value; } }

    private void Update()
    {
        if (_inputKind == 0)
        {
            IsUp = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
            IsDown = Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S);
            IsRight = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);
            IsLeft = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A);
            IsNext = Input.GetKeyDown(KeyCode.Space);
            IsBack = Input.GetKeyDown(KeyCode.Escape);
            IsReturn = Input.GetKeyDown(KeyCode.Backspace);
        }

        else if ((int)_inputKind == 1)
        {
            _move.x = Input.GetAxis(X_DIR);
            _move.z = Input.GetAxis(Z_DIR);
        }
    }
}
