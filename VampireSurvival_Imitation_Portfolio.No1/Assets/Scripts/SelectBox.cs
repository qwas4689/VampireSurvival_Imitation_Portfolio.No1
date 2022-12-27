using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using ETypeSelect = Define.EPanelType;


public class SelectBox : MonoBehaviour
{
    [SerializeField] private Image[] _characters;
    [SerializeField] private Image[] _maps;
    [SerializeField] private ETypeSelect _eTypeSelect;

    // 상하좌우
    private int[] _characterLookUpTable = { -3, 3, 1, -1 };
    // 상하
    private int[] _mapLookUpTable = { -1, 1 };

    private const int UP = 0;
    private const int DOWN = 1;
    private const int RIGHT = 2;
    private const int LEFT = 3;

    private const int DEFAULT_VALUE = 0;
    private bool isTimeOn = false;
    private float flickerTime;

    private int _characterIndex;
    private int _mapIndex;

    private void Update()
    {
        if (_eTypeSelect == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _characters[_characterIndex].color = Color.white;
                if (_characterIndex == 0)
                {
                    _characterIndex = _characters.Length - 3;
                }
                else if (_characterIndex == 1)
                {
                    _characterIndex = _characters.Length - 2;
                }
                else if (_characterIndex == 2)
                {
                    _characterIndex = _characters.Length - 1;
                }
                else if (_characterIndex > _characters.Length - 1)
                {
                    _characterIndex = _characterIndex - _characters.Length - 1;
                }
                else
                {
                    _characterIndex += _characterLookUpTable[UP];
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _characters[_characterIndex].color = Color.white;
                if (_characterIndex == _characters.Length - 3)
                {
                    _characterIndex = DEFAULT_VALUE;
                }
                else if (_characterIndex == _characters.Length - 2)
                {
                    _characterIndex = 1;
                }
                else if (_characterIndex == _characters.Length - 1)
                {
                    _characterIndex = 2;
                }
                else
                {
                    _characterIndex += _characterLookUpTable[DOWN];
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _characters[_characterIndex].color = Color.white;
                if (_characters.Length - 1 <= _characterIndex)
                {
                    _characterIndex = DEFAULT_VALUE;
                }
                else
                {
                    _characterIndex += _characterLookUpTable[RIGHT];
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _characters[_characterIndex].color = Color.white;
                if (_characterIndex <= DEFAULT_VALUE)
                {
                    _characterIndex = _characters.Length - 1;
                }
                else
                {
                    _characterIndex += _characterLookUpTable[LEFT];
                }
            }
            Flicker(_characters[_characterIndex]);
        }

        if ((int)_eTypeSelect == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _maps[_mapIndex].color = Color.white;
                if (_mapIndex <= 0)
                {
                    _mapIndex = _maps.Length - 1;
                }
                else
                {
                    _mapIndex += _mapLookUpTable[UP];
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _maps[_mapIndex].color = Color.white;
                if (_mapIndex >= _maps.Length - 1)
                {
                    _mapIndex = DEFAULT_VALUE;
                }
                else
                {
                    _mapIndex += _mapLookUpTable[DOWN];
                }
            }

            Flicker(_maps[_mapIndex]);
        }
    }

    private void Flicker(Image img)
    {
        flickerTime += Time.deltaTime;

        img.color = isTimeOn == false ? Color.yellow : Color.white;

        if (flickerTime > 0.4f)
        {
            isTimeOn = !isTimeOn;
            flickerTime -= flickerTime;
        }
    }
}
