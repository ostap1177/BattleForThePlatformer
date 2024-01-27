using System.Collections;
using UnityEngine;

public class HealthDisplayBar : Bar
{
    [SerializeField] private float _stepHealth;
    [SerializeField] private float _delay;
    [SerializeField] private HealthCounter _playerHealth;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _launchedControlHealthBar;

    private void Awake()
    {
        _healthSlider.value = 1;
    }

    private void OnEnable()
    {
        _playerHealth.Changed += OnChange;
    }

    private void OnDisable()
    {
        _playerHealth.Changed -= OnChange;
    }

    private void OnChange(float health,float maxHealth)
    {
        float targetValue = GetNormalizeValue(health, maxHealth);

        if (_launchedControlHealthBar != null)
        {
            StopCoroutine(ControlBar(targetValue));
        }

        _launchedControlHealthBar = StartCoroutine(ControlBar(targetValue));
    }

    private IEnumerator ControlBar(float targetValue)
    {
        _waitForSeconds = new WaitForSeconds(_delay);

        while (_healthSlider.value != targetValue)
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, targetValue, _stepHealth);

            yield return _waitForSeconds;
        }
    }
}