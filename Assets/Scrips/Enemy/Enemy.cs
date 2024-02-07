using UnityEngine;

public class Enemy : HealthCounter
{
    [SerializeField] private int _attackPower = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player) == true)
        {
            TakeDamage(player.Attack());
        }
    }

    public int Attack()
    {
        return _attackPower;
    }
}
