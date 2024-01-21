using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 4;
    [SerializeField] private int _attackPower = 2;

    private int _coinCounter;

    private void Update()
    {
        if (_health <= 0)
        {
            Dai();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin) == true)
        {
            _coinCounter++;
            Destroy(collision.gameObject);
        }

        if (collision.TryGetComponent(out MedicineChest medicineChest) == true)
        {
            Healing(medicineChest.Healing());
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy) == true)
        {
            TakeDamage(enemy.Attack());
        }
    }

    public int Attack()
    {
        return _attackPower;
    }

    private void TakeDamage(int damage)
    {   
        _health -= damage;
    }

    private void Healing(int heal)
    {
        _health += heal;
    }

    private void Dai()
    {
        gameObject.SetActive(false);
    }

}

