using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _attackPower = 2;

    private int _coinCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin) == true)
        {
            _coinCounter++;
            Destroy(collision.gameObject);
        }
    }

    public int Attack()
    {
        return _attackPower;
    }
}

