using UnityEngine;

public class HealthDisplayBarSteps : Bar
{
    [SerializeField] private HealthCounter _playerHealth;

    private void Awake()
    {
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

    private void OnChanged(float health, float maxHealth)
    {
        _healthSlider.value = GetNormalizeValue(health, maxHealth);
    }
}
