using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider _healthSlider;
    [SerializeField] private HealthCounter _playerHealth;

    private void OnEnable()
    {
        _playerHealth.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _playerHealth.Changed -= OnChanged;
    }

    protected float GetNormalizeValue(float value, float maxValue)
    {
        return value / maxValue;
    }

    protected abstract void OnChanged(float health, float maxHealth);
}
