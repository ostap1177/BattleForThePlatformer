using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityVampirism : MonoBehaviour
{
    [SerializeField] private int _vampirismPower;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private HealthCounter _health;
    [SerializeField] private KeyCode _key;
 
    private void Awake()
    {
        _collider.isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy) == true && Input.GetKeyDown(_key))
        {
            Vampirism(enemy);
        }
    }

    private void Vampirism(Enemy enemy)
    {
        if (enemy.gameObject.TryGetComponent(out HealthCounter healthCounter) == true)
        {
            healthCounter.TakeDamage(_vampirismPower);
            _health.Healing(_vampirismPower);
        }
    }
}
