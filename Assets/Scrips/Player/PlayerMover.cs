using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedJump;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Mover();
    }

    private void Mover()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        _animator.SetBool("Move",moveHorizontal != 0);
        transform.Translate(_speed * moveHorizontal * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            transform.Translate(0, _speedJump * Time.deltaTime, 0);
        }
    }
}
