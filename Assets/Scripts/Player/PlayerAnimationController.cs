using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private Vector2 _lastMovement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _lastMovement = Vector2.down;
    }

    public void UpdateMovementAnimation(Vector2 movement)
    {
        if (movement != Vector2.zero)
        {
            _animator.SetBool("IsMoving", true);
            _animator.SetFloat("MoveX", movement.x);
            _animator.SetFloat("MoveY", movement.y);
            _lastMovement = movement;
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }

        _animator.SetFloat("LastMoveX", _lastMovement.x);
        _animator.SetFloat("LastMoveY", _lastMovement.y);
    }
}