using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _attackPower = 1;
    [SerializeField] private HealthCounter _healthCounter;

    public int Attack => _attackPower;

    private void OnollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player) == true)
        {
            _healthCounter.TakeDamage(player.Attack);
        }
    }
}
