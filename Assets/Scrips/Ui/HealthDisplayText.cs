using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class HealthDisplayText : MonoBehaviour
{
    [SerializeField] private HealthCounter _playerHealth;
    [SerializeField] private string _nameText;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _playerHealth.Changed += OnChange;
    }

    private void OnDisable()
    {
        _playerHealth.Changed -= OnChange;
    }

    private void OnChange(float health, float maxHealth)
    {
       _text.text = $"{_nameText}: {health}/{maxHealth}"; 
    }
}
