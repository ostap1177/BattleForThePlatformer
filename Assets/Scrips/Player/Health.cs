using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthValue = 10;
    [SerializeField] private float _minHealth;

    public event UnityAction<float,float> Changed;
    private float _maxHealth;

    private void Awake()
    {
        _maxHealth = _healthValue;
        Changed?.Invoke(_healthValue,_maxHealth);
    }

    public void TakeDamage(float damage)
    {
        float tempHealth = _healthValue - damage;
        _healthValue = Mathf.Clamp(tempHealth, _minHealth, _maxHealth);
        Changed?.Invoke(_healthValue, _maxHealth);

        if (_healthValue <= _minHealth)
        {
            Die();
        }
    }

    public void Healing(float heal)
    {
        float tempHealth = _healthValue + heal;
        _healthValue = Mathf.Clamp(tempHealth, _minHealth, _maxHealth);
        Changed?.Invoke(_healthValue, _maxHealth);
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
