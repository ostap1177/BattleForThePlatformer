using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthDisplayBarSteps : MonoBehaviour
{
    [SerializeField] private HealthCounter _playerHealth;

    private Slider _healthSlider;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
        _healthSlider.value = 1;
    }

    private void OnEnable()
    {
        _playerHealth.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _playerHealth.Changed -= OnChanged;
    }

    private void OnChanged(float value, float maxValue)
    {
        _healthSlider.value = value / maxValue;
    }
}
