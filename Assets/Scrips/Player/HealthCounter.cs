using UnityEngine;
using UnityEngine.Events;

public class HealthCounter : MonoBehaviour
{
    [SerializeField] private float _health = 10;
    [SerializeField] private float _minHealth;

    public event UnityAction<float,float> Changed;
    private float _maxHealth;

    private void Awake()
    {
        _maxHealth = _health;
        Changed?.Invoke(_health,_maxHealth);
    }

    public void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health - damage, _minHealth, _maxHealth);
        Changed?.Invoke(_health, _maxHealth);

        if (_health <= _minHealth)
        {
            Die();
        }
    }

    public void Healing(int heal)
    {
        _health = Mathf.Clamp(_health + heal, _minHealth, _maxHealth);
        Changed?.Invoke(_health, _maxHealth);
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
