using UnityEngine;

public class PathPointsEnemy : MonoBehaviour
{
    [SerializeField] private Transform  _path;
    [SerializeField] private float _speed;
    [SerializeField] private Scaning _scaning;

    private Transform[] _wayPoints;
    private int _curentPoint;
    private SpriteRenderer _enemySprite;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _enemySprite = gameObject.GetComponent<SpriteRenderer>();

        _wayPoints = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _wayPoints[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        MovePoint();
    }

    private void MovePoint()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, GetNextPoint().position, _speed * Time.deltaTime);
    }

    private Transform GetNextPoint()
    {
        Transform targer = _wayPoints[_curentPoint];
        int lastPoint = 0;
        
        if (_scaning.TryGetTransformPlayer(out Transform transformTarget) == true)
        {
            lastPoint = _curentPoint;
            return targer = transformTarget;
        }
        else
        {
            if (_transform.position == targer.position)
            {
                _curentPoint++;

                _enemySprite.flipX = !_enemySprite.flipX;

                if (_curentPoint >= _wayPoints.Length)
                {
                    _curentPoint = 0;
                }
            }
        }

        return targer;
    }
}
