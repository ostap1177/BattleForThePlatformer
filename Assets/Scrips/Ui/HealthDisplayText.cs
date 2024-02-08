using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class HealthDisplayText : Bar
{
    [SerializeField] private string _nameText;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    protected override void OnChanged(float health, float maxHealth)
    {
       _text.text = $"{_nameText}: {health}/{maxHealth}"; 
    }
}
