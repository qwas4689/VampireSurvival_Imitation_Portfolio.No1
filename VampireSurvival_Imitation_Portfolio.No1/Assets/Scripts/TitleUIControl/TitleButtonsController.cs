using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleButtonsController : MonoBehaviour
{
    [SerializeField] private Button[] _titleButtons;

    [SerializeField] private GameObject _characterSelectPanel;
    [SerializeField] private GameObject _abilityPanel;
    [SerializeField] private GameObject _optionPanel;

    [SerializeField] private PlayerInput _playerInput;

    [SerializeField] private RectTransform _selectArrow;

    public Stack<GameObject> UIStack = new Stack<GameObject>();

    private Vector2[] _selectArrowLookUpTable = { new Vector2(0, 80), new Vector2(0, -80) };

    private Vector2[] _limitRange = { new Vector2(-175, -155), new Vector2(-175, -395) };

    private const int UP = 0;
    private const int DOWN = 1;

    private const int START_BUTTON = 0;
    private const int ABILITY_BUTTON = 1;
    private const int OPTION_BUTTON = 2;
    private const int EXIT_BUTTON = 3;

    private int _moveArrowCount;

    private void Start()
    {
        AddButtonEvents();
    }

    private void Update()
    {
        if (_playerInput.IsBack && UIStack.Count > 0)
        {
            UIStack.Peek().SetActive(false);
            UIStack.Pop();
        }
        if (UIStack.Count == 0)
        {
            MoveSelectArrow();
            SelectButton();
        }
    }

    private void MoveSelectArrow()
    {
        if (_playerInput.IsUp)
        {
            if (_selectArrow.anchoredPosition.y >= _limitRange[UP].y)
            {
                _selectArrow.anchoredPosition = _limitRange[DOWN];
            }
            else
            {
                _selectArrow.anchoredPosition += _selectArrowLookUpTable[UP];
            }

            ++_moveArrowCount;
        }
        if (_playerInput.IsDown)
        {
            if (_selectArrow.anchoredPosition.y <= _limitRange[DOWN].y)
            {
                _selectArrow.anchoredPosition = _limitRange[UP];
            }
            else
            {
                _selectArrow.anchoredPosition += _selectArrowLookUpTable[DOWN];
            }

            --_moveArrowCount;
        }
    }

    private void SelectButton()
    {
        int buttonInvokeIndex;

        if (_playerInput.IsNext)
        {
            buttonInvokeIndex = _moveArrowCount % 4;
            if (buttonInvokeIndex < 0)
            {
                buttonInvokeIndex *= -1;
            }
            _titleButtons[buttonInvokeIndex].onClick.Invoke();
        }
    }

    private void AddButtonEvents()
    {
        _titleButtons[START_BUTTON].onClick.RemoveListener(OnClickStartButton);
        _titleButtons[START_BUTTON].onClick.AddListener(OnClickStartButton);

        _titleButtons[ABILITY_BUTTON].onClick.RemoveListener(OnClickAbilityButton);
        _titleButtons[ABILITY_BUTTON].onClick.AddListener(OnClickAbilityButton);

        _titleButtons[OPTION_BUTTON].onClick.RemoveListener(OnClickOptionButton);
        _titleButtons[OPTION_BUTTON].onClick.AddListener(OnClickOptionButton);

        _titleButtons[EXIT_BUTTON].onClick.RemoveListener(OnClickExitButton);
        _titleButtons[EXIT_BUTTON].onClick.AddListener(OnClickExitButton);
    }

    private void OnClickStartButton()
    {
        UIStack.Push(_characterSelectPanel);
        _characterSelectPanel.SetActive(true);
    }

    private void OnClickAbilityButton()
    {
        UIStack.Push(_abilityPanel);
        _abilityPanel.SetActive(true);
    }

    private void OnClickOptionButton()
    {
        UIStack.Push(_optionPanel);
        _optionPanel.SetActive(true);
    }

    private void OnClickExitButton()
    {
        Application.Quit();
    }

    private void OnDisable()
    {
        _titleButtons[START_BUTTON].onClick.RemoveListener(OnClickStartButton);
        _titleButtons[ABILITY_BUTTON].onClick.RemoveListener(OnClickAbilityButton);
        _titleButtons[OPTION_BUTTON].onClick.RemoveListener(OnClickOptionButton);
        _titleButtons[EXIT_BUTTON].onClick.RemoveListener(OnClickExitButton);
    }
}
