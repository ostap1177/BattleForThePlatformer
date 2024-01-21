using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCoin : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private float _timeToCreate;
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private Vector3 _createPosition;

    private Coroutine _coinCreated;
    private Coin _coinClone;
    private WaitForSeconds _waitForSeconds;
   
    private void Start()
    {
        _coinCreated = StartCoroutine(Created());
    }

    private IEnumerator Created()
    {
        _waitForSeconds = new WaitForSeconds(_timeToCreate);

        while (transform.childCount == 0)
        {
            _coinClone = Instantiate(_coin, transform.position + _createPosition, Quaternion.identity, gameObject.transform);
            Destroy(_coinClone.gameObject,_timeToDestroy);

            yield return _waitForSeconds;
        }
    }
}