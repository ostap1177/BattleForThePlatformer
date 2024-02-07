using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedJump;

    private Animator _animator;
    private int _idAnimationMove;
    private string _nameAnimation = "Move";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _idAnimationMove = Animator.StringToHash(_nameAnimation);
    }

    private void Update()
    {
        Mover();
    }

    private void Mover()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        _animator.SetBool(_idAnimationMove,moveHorizontal != 0);
        transform.Translate(_speed * moveHorizontal * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            transform.Translate(0, _speedJump * Time.deltaTime, 0);
        }
    }
}