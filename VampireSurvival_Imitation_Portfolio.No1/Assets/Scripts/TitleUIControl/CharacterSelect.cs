using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] private Image[] _characters;
    [SerializeField] private PlayerInput _playerInput;

    [SerializeField] private Stat _stat;
    [SerializeField] private GameObject _mapPanel;
    [SerializeField] private TitleButtonsController _titleButtonsController;

    // »óÇÏÁÂ¿ì
    private int[] _characterLookUpTable = { -3, 3, 1, -1 };


    private const int UP = 0;
    private const int DOWN = 1;
    private const int RIGHT = 2;
    private const int LEFT = 3;

    private const int DEFAULT_VALUE = 0;
    private bool isTimeOn = false;
    private float flickerTime;

    private int _characterIndex;
    public int CharacterIndex { get { return _characterIndex; } set { _characterIndex = value; } }

    private void Update()
    {
        Debug.Log(_characterIndex);
        if (_titleButtonsController.UIStack.Count == 1)
        {
            if (_playerInput.IsUp)
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

            if (_playerInput.IsDown)
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

            if (_playerInput.IsRight)
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

            if (_playerInput.IsLeft)
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

            _stat.IndexChange.Invoke();
            Flicker(_characters[_characterIndex]);

            if (_playerInput.IsNext)
            {
                _titleButtonsController.UIStack.Push(_mapPanel);
                _mapPanel.SetActive(true);
            }
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
