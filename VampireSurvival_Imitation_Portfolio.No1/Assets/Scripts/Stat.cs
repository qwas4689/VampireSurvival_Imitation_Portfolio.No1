using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using ChampionData = Champion.ChampionData;

public class Stat : MonoBehaviour
{
    [SerializeField] private SelectBox _selectBox;
    [SerializeField] private TextMeshProUGUI[] _statText;

    private ChampionData _championData;

    public Action IndexChange;

    private void Start()
    {
        IndexChange = SetStat;
    }

    private void SetStat()
    {
        if (_selectBox.CharacterIndex == 0)
        {
            _championData.Name = "Android";
            _championData.AttackPower = 1;
            _championData.HP = 100;
            _championData.DefensivePower = 1;
            _championData.Speed = 0.7f;
            _championData.AcquisitionRange = 100;
            _championData.EXP = 100;
        }
        else if (_selectBox.CharacterIndex == 1)
        {
            _championData.Name = "Skeleton";
            _championData.AttackPower = 2;
            _championData.HP = 70;
            _championData.DefensivePower = 2;
            _championData.Speed = 1;
            _championData.AcquisitionRange = 150;
            _championData.EXP = 150;
        }
        else if (_selectBox.CharacterIndex == 2)
        {
            _championData.Name = "DemiGod";
            _championData.AttackPower = 3;
            _championData.HP = 50;
            _championData.DefensivePower = 3;
            _championData.Speed = 0.7f;
            _championData.AcquisitionRange = 70;
            _championData.EXP = 70;
        }
        else if (_selectBox.CharacterIndex == 3)
        {
            _championData.Name = null;
            _championData.AttackPower = 0;
            _championData.HP = 0;
            _championData.DefensivePower = 0;
            _championData.Speed = 0f;
            _championData.AcquisitionRange = 0;
            _championData.EXP = 0;
        }
        else if (_selectBox.CharacterIndex == 4)
        {
            _championData.Name = null;
            _championData.AttackPower = 0;
            _championData.HP = 0;
            _championData.DefensivePower = 0;
            _championData.Speed = 0f;
            _championData.AcquisitionRange = 0;
            _championData.EXP = 0;
        }
        else if (_selectBox.CharacterIndex == 5)
        {
            _championData.Name = null;
            _championData.AttackPower = 0;
            _championData.HP = 0;
            _championData.DefensivePower = 0;
            _championData.Speed = 0f;
            _championData.AcquisitionRange = 0;
            _championData.EXP = 0;
        }
        else if (_selectBox.CharacterIndex == 6)
        {
            _championData.Name = null;
            _championData.AttackPower = 0;
            _championData.HP = 0;
            _championData.DefensivePower = 0;
            _championData.Speed = 0f;
            _championData.AcquisitionRange = 0;
            _championData.EXP = 0;
        }

        _statText[0].text = _championData.Name;
        _statText[1].text = _championData.AttackPower.ToString();
        _statText[2].text = _championData.HP.ToString();
        _statText[3].text = _championData.DefensivePower.ToString();
        _statText[4].text = _championData.Speed.ToString();
        _statText[5].text = _championData.AcquisitionRange.ToString() + "%";
        _statText[6].text = _championData.EXP.ToString() + "%";
    }
}
