using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] protected Slider _slider;

    public void OnValueChanged(float value, float maxValue)
    {
        _slider.value = value / maxValue;
    }
}
