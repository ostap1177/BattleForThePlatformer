using System.Collections;
using UnityEngine;

public class AbilityVampirism : MonoBehaviour
{
    [SerializeField] private int _vampirismPower;
    [SerializeField] private int _vampirismTime;
    [SerializeField] private int _vampirismDistance;
    [SerializeField] private string _layreMaskToVampirism;
    [SerializeField] private Player _player;

    private Health _health;
    private int _secondsWait = 1;
    private WaitForSeconds _waitForSeconds;
    private Coroutine _vampirismTimer;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_secondsWait);
        _health = _player.GetComponent<Health>();
    }

    private void OnEnable()
    {
        _player.AbilityEnabled += OnAbilityEnabled;
    }

    private void OnDisable()
    {
        _player.AbilityEnabled -= OnAbilityEnabled;
    }

    private void OnAbilityEnabled()
    {
        if (_vampirismTimer != null)
        {
            StopCoroutine(_vampirismTimer);
        }

        _vampirismTimer = StartCoroutine(VampirismTimer());
    }

    private IEnumerator VampirismTimer()
    {
        RaycastHit2D[] raycastHits = Physics2D.CircleCastAll(transform.position,_vampirismDistance, Vector3.up,0,LayerMask.GetMask(_layreMaskToVampirism));

        for (int i = 0; i < _vampirismTime; i++)
        {
            foreach (var enemy in raycastHits)
            {
                if (enemy.transform.TryGetComponent(out Enemy enemyToAttack) == true && enemyToAttack.TryGetComponent(out Health healthEnemy)==true)
                {
                    healthEnemy.TakeDamage(_vampirismPower);
                    _health.Healing(_vampirismPower);
                }
            }

            yield return _waitForSeconds;
        }
    }
}
