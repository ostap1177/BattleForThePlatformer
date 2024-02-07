using UnityEngine;

public class Enemy : HealthCounter
{
    //[SerializeField] private int _health = 5;
    [SerializeField] private int _attackPower = 1;

    //private void Update()
    //{
    //    if (_health <= 0)
    //    {
    //        Dai();
    //    }
    //}

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

    //private void TakeDamage(int damage)
    //{
    //    _health -= damage;
    //}

    //private void Dai()
    //{
    //    gameObject.SetActive(false);
    //}
}
