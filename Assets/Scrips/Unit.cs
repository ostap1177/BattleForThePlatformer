using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Unit : MonoBehaviour
{
    [SerializeField] protected int _attackPower = 1;
    protected Health _healthCounter;

    public int Attack => _attackPower;

    private void Awake()
    {
        _healthCounter = GetComponent<Health>();
    }
}
