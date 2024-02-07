using UnityEngine;

public class HealthDisplayBarSteps : Bar
{

    private void Awake()
    {
        _healthSlider.value = 1;
    }

    protected override void OnChanged(float health, float maxHealth)
    {
        _healthSlider.value = GetNormalizeValue(health, maxHealth);
    }
}
