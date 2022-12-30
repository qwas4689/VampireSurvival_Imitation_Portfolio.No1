using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ability : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private TextMeshProUGUI[] _abilityTexts;
    public TextMeshProUGUI[] AbilityTexts { get { return _abilityTexts; } private set { _abilityTexts = value; } }

    [SerializeField] private RectTransform _abilityArrow;
 

    private int[] _abilityLookUpTable = { -2, 2, 1, -1 };
    private Vector2[] _abilityArrowLookUpTable = { new Vector2(0, 235), new Vector2(0, -235), new Vector2(600, 0), new Vector2(-600, 0) };
    private Vector2[] _abilityRange = { new Vector2(-460, 155), new Vector2(140, 155), new Vector2(-460, -315), new Vector2 (140, -315) };

    private int _abilityIndex;
    public int AbilityIndex { get { return _abilityIndex; } private set { _abilityIndex = value; } }
    private const int UP = 0;
    private const int DOWN = 1;
    private const int RIGHT = 2;
    private const int LEFT = 3;

    private const int DEFAULT_VALUE = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (_playerInput.IsUp)
        {
            if (_abilityIndex == 0)
            {
                _abilityIndex = _abilityTexts.Length - 2;
                _abilityArrow.anchoredPosition = _abilityRange[2];
            }
            else if (_abilityIndex == 1)
            {
                _abilityIndex = _abilityTexts.Length - 1;
                _abilityArrow.anchoredPosition = _abilityRange[3];
            }
            else
            {
                _abilityIndex += _abilityLookUpTable[UP];
                _abilityArrow.anchoredPosition += _abilityArrowLookUpTable[UP];
            }
        }

        if (_playerInput.IsDown)
        {
            if (_abilityIndex == _abilityTexts.Length - 2)
            {
                _abilityIndex = DEFAULT_VALUE;
                _abilityArrow.anchoredPosition = _abilityRange[0];
            }
            else if (_abilityIndex == _abilityTexts.Length - 1)
            {
                _abilityIndex = 1;
                _abilityArrow.anchoredPosition = _abilityRange[1];
            }
            else
            {
                _abilityIndex += _abilityLookUpTable[DOWN];
                _abilityArrow.anchoredPosition += _abilityArrowLookUpTable[DOWN];
            }
        }

        if (_playerInput.IsRight)
        {
            if (_abilityTexts.Length - 1 <= _abilityIndex)
            {
                _abilityIndex = DEFAULT_VALUE;
                _abilityArrow.anchoredPosition = _abilityRange[0];
            }
            else if (_abilityIndex % 2 == 1)
            {
                _abilityIndex += _abilityLookUpTable[RIGHT];
                _abilityArrow.anchoredPosition += _abilityArrowLookUpTable[DOWN] + _abilityArrowLookUpTable[LEFT];
            }
            else
            {
                _abilityIndex += _abilityLookUpTable[RIGHT];
                _abilityArrow.anchoredPosition += _abilityArrowLookUpTable[RIGHT];
            }
        }

        if (_playerInput.IsLeft)
        {
            if (_abilityIndex <= DEFAULT_VALUE)
            {
                _abilityIndex = _abilityTexts.Length - 1;
                _abilityArrow.anchoredPosition = _abilityRange[3];
            }
            else if (_abilityIndex % 2 == 0)
            {
                _abilityIndex += _abilityLookUpTable[LEFT];
                _abilityArrow.anchoredPosition += _abilityArrowLookUpTable[UP] + _abilityArrowLookUpTable[RIGHT];
            }
            else
            {
                _abilityIndex += _abilityLookUpTable[LEFT];
                _abilityArrow.anchoredPosition += _abilityArrowLookUpTable[LEFT];
            }
        }
    }
}
