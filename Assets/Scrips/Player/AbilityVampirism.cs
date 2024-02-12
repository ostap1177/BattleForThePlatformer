using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class AbilityVampirism : MonoBehaviour
{
    [SerializeField] private int _vampirismPower;
    [SerializeField] private int _vampirismTime;
    [SerializeField] private HealthCounter _health;
    [SerializeField] private Player _player;

    private Enemy _enemy;

    private int _seconds = 1;
    private WaitForSeconds _waitForSeconds;
    private Coroutine _vampirismTimer;

    private void Awake()
    {
        transform.GetComponent<CircleCollider2D>().isTrigger = true;
        _waitForSeconds = new WaitForSeconds(_seconds);
    }

    private void OnEnable()
    {
        _player.VampirismActivating += OnVampirismActivating;
    }

    private void OnDisable()
    {
        _player.VampirismActivating -= OnVampirismActivating;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy) == true)
        {
            _enemy = enemy;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy) == true)
        {
            _enemy = null;
        }
    }

    private void OnVampirismActivating()
    {
        Vampirism();
    }

    private void Vampirism()
    {
        if(_vampirismTimer != null)
        {
            StopCoroutine(_vampirismTimer);
        }

        _vampirismTimer = StartCoroutine(VampirismTimer());
    }

    private IEnumerator VampirismTimer()
    {
        for(int i=0; i<_vampirismTime; i++)
        {
            if (_enemy != null && _enemy.gameObject.TryGetComponent(out HealthCounter healthCounter) == true)
            {
                healthCounter.TakeDamage(_vampirismPower);
                _health.Healing(_vampirismPower);
                Debug.Log(name);
            }

            yield return _waitForSeconds;
        }
    }
}
