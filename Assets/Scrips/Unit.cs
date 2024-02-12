using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] protected int _attackPower = 1;
    [SerializeField] protected HealthCounter _healthCounter;

    public int Attack => _attackPower;
}
