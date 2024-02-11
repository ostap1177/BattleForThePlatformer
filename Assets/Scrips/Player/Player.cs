using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _attackPower = 2;
    [SerializeField] private HealthCounter _healthCounter;

    public int Attack => _attackPower;

    private int _coinCounter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy) == true)
        {
            _healthCounter.TakeDamage(enemy.Attack);
        }

        if (collision.gameObject.TryGetComponent(out Coin coin) == true)
        {
            _coinCounter++;
            Destroy(collision.gameObject);
        }
    }
}

