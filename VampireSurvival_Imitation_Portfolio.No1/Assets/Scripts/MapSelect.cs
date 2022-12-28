using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapSelect : MonoBehaviour
{
    [SerializeField] private Image[] _maps;
    [SerializeField] private PlayerInput _playerInput;

    private int _mapIndex;

    // ªÛ«œ
    private int[] _mapLookUpTable = { -1, 1 };

    private const int DEFAULT_VALUE = 0;
    private const int UP = 0;
    private const int DOWN = 1;

    private bool isTimeOn = false;
    private float flickerTime;

    void Update()
    {
        if (_playerInput.IsUp)
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

        if (_playerInput.IsDown)
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

        if (_playerInput.IsNext)
        {
            SceneManager.LoadScene(1);
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
