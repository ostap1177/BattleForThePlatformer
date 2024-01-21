using UnityEngine;

public class MedicineChest : MonoBehaviour
{
    [SerializeField] private int _healingPoint;

    public int Healing()
    {
        return _healingPoint;
    }
}
