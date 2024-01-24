using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health = 10;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private UnityEvent _rendered;

    public event UnityAction<float,float> Changed;

    private void Awake()
    {
        Changed?.Invoke(_health,_maxHealth);
    }

    private void Update()
    {
        if (_health <= 0)
        {
            Dai();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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

    private void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health - damage, _minHealth, _maxHealth);
        Changed?.Invoke(_health, _maxHealth);


    }

    private void Healing(int heal)
    {
        _health = Mathf.Clamp(_health + heal, _minHealth, _maxHealth);
        EalthNormolayz();
        //Changed?.Invoke(_health);
    }

    private void EalthNormolayz()
    {
        float healthNormolayz = _health/ _maxHealth;
       // Changed?.Invoke(healthNormolayz);
    }

    private void Dai()
    {
        gameObject.SetActive(false);
    }
}
