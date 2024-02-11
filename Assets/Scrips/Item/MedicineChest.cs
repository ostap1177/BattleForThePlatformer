using UnityEngine;

public class MedicineChest : MonoBehaviour
{
    [SerializeField] private int _healingPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthCounter healthCounter) == true)
        {
            healthCounter.Healing(_healingPoint);
            Destroy(gameObject);
        }
    }
}