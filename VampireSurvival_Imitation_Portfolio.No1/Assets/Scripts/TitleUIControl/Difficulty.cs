using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Difficulty : MonoBehaviour
{
    [SerializeField] private Toggle[] _toggle;
    [SerializeField] private TextMeshProUGUI _difficultyPercentText;

    private const int EASY_TOGGLE = 0;
    private const int NORMAL_TOGGLE = 1;
    private const int HARD_TOGGLE = 2;

    private const int EASY_IS_ON = 70;
    private const int NORMAL_IS_ON = 100;
    private const int HARD_IS_ON = 200;

    private int _difficultyPercent;

    // ��� ��ư�� ������ ���̵��� �ش�Ǵ� ���� �����ֱ�
    // ��� ��ư�� ������ ���̵��� �ش�Ǵ� ���� ���ֱ�

    private void Start()
    {
        _toggle[EASY_TOGGLE].onValueChanged.AddListener( delegate { ToggleChange(_toggle[EASY_TOGGLE], EASY_IS_ON); });
        _toggle[NORMAL_TOGGLE].onValueChanged.AddListener(delegate { ToggleChange(_toggle[NORMAL_TOGGLE], NORMAL_IS_ON); });
        _toggle[HARD_TOGGLE].onValueChanged.AddListener(delegate { ToggleChange(_toggle[HARD_TOGGLE], HARD_IS_ON); });
    }

    private void ToggleChange(Toggle tog, int difficulty)
    {
        if (tog.isOn)
        {
            _difficultyPercent += difficulty;
        }
        else
        {
            _difficultyPercent -= difficulty;
        }

        _difficultyPercentText.text = _difficultyPercent.ToString() + "%";
    }
}
