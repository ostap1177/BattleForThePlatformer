using UnityEngine;
using UnityEngine.UI;


//[RequireComponent(typeof(Slider))]
public class Bar : MonoBehaviour
{
    [SerializeField] protected Slider _healthSlider;

    private void Awake()
    {
        //_healthSlider = GetComponent<Slider>();
    }

    protected float GetNormalizeValue (float value, float maxValue)
    {
       return value / maxValue;
    }
}
