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


    private void Start()
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
        _characterSelectPanel.SetActive(true);
    }

    private void OnClickAbilityButton()
    {
        _abilityPanel.SetActive(true);
    }

    private void OnClickOptionButton()
    {
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
