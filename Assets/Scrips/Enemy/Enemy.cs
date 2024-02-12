using UnityEngine;

public class Enemy : Unit
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player) == true)
        {
            _healthCounter.TakeDamage(player.Attack);
        }
    }
}
