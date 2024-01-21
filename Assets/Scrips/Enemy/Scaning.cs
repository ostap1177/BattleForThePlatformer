using UnityEngine;

public class Scaning : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _scaningCollider2D;

    private Transform _transformPlayer;

    private void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.TryGetComponent(out Player player))
        {
            _transformPlayer = player.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.TryGetComponent(out Player player))
        {
            _transformPlayer = null;
        }
    }

    public bool TryGetTransformPlayer(out Transform transformPlayer)
    {
        if (_transformPlayer != null)
        {
            transformPlayer = _transformPlayer;
        }
        else
        {
            transformPlayer = null;
        }

        return transformPlayer != null;
    }

    public Vector3 GetTransformPlayer()
    {
        if (_transformPlayer != null)
        {
            return _transformPlayer.position;
        }

        return Vector3.zero;
    }
}
