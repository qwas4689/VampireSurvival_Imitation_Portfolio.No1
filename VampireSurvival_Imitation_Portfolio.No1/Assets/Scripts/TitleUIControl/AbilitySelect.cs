using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AbilityKind = Define.EAbility;

public class AbilitySelect : MonoBehaviour
{
    [SerializeField] private AbilityKind _abilityKind;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Ability _ability;
    [SerializeField] private Toggle[] _abilityToggle;

    private int _abilityCount;
    public int AbilityCount { get { return _abilityCount; } private set { _abilityCount = value; } }

    private void Update()
    {
        if (_playerInput.IsNext)
        {
            if ((int)_abilityKind == _ability.AbilityIndex)
            {
                AbilityUp();
            }
        }
        else if (_playerInput.IsReturn)
        {
            AbilityReset();
        }
        
    }

    private void AbilityUp()
    {
        if (_abilityCount >= _abilityToggle.Length)
        {
            return;
        }

        for (int i = 0; i < _abilityToggle.Length; ++i)
        {
            if (_abilityToggle[i].isOn == false)
            {
                ++_abilityCount;
                _abilityToggle[i].isOn = true;
                return;
            }
        }
    }

    private void AbilityReset()
    {
        if (_abilityCount == 0)
        {
            return;
        }

        for (int i = 0; i < _abilityToggle.Length; ++i)
        {
            if (_abilityToggle[i].isOn == true)
            {
                _abilityToggle[i].isOn = false;
            }
        }
        _abilityCount = 0;
    }
}
