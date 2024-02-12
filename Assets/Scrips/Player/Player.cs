using UnityEngine;
using UnityEngine.Events;

public class Player : Unit
{
    [SerializeField] private KeyCode _key;

    public event UnityAction VampirismActivating;

    private int _coinCounter;

    private void Update()
    {
        if (Input.GetKeyDown(_key) == true)
        {
            VampirismActivating?.Invoke();
        }
    }

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

