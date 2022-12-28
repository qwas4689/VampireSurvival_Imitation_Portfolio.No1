using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleButtonsController : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _abilityButton;
    [SerializeField] private Button _optionButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private GameObject _characterSelectPanel;
    [SerializeField] private GameObject _abilityPanel;
    [SerializeField] private GameObject _optionPanel;

    [SerializeField] private PlayerInput _playerInput;

    [SerializeField] private RectTransform _selectArrow;

    public Stack<GameObject> UIStack = new Stack<GameObject>();

    private int[] _selectArrowLookUpTable = { 80, -80 };

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
    }

    private void MoveSelectArrow()
    {
        if (_playerInput.IsUp)
        {

        }
        if (_playerInput.IsDown)
        {

        }
    }

    private void AddButtonEvents()
    {
        _startButton.onClick.RemoveListener(OnClickStartButton);
        _startButton.onClick.AddListener(OnClickStartButton);

        _abilityButton.onClick.RemoveListener(OnClickAbilityButton);
        _abilityButton.onClick.AddListener(OnClickAbilityButton);

        _optionButton.onClick.RemoveListener(OnClickOptionButton);
        _optionButton.onClick.AddListener(OnClickOptionButton);

        _optionButton.onClick.RemoveListener(OnClickExitButton);
        _optionButton.onClick.AddListener(OnClickExitButton);
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
        _startButton.onClick.RemoveListener(OnClickStartButton);
        _abilityButton.onClick.RemoveListener(OnClickAbilityButton);
        _optionButton.onClick.RemoveListener(OnClickOptionButton);
        _optionButton.onClick.RemoveListener(OnClickExitButton);
    }
}
