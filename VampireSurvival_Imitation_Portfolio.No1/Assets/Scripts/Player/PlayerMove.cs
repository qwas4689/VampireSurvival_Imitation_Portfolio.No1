using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChampionData = Champion.ChampionData;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private StatManager _stat;

    private void Start()
    {
        Debug.Log(_stat.Instance.ChampionData.Speed);
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + _playerInput.Move * (_stat.Instance.ChampionData.Speed * Time.fixedDeltaTime));
    }
}
