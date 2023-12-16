using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private Vector2 lastMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        lastMovement = Vector2.down;
    }

    public void UpdateMovementAnimation(Vector2 movement)
    {
        if (movement != Vector2.zero)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveX", movement.x);
            animator.SetFloat("MoveY", movement.y);
            lastMovement = movement;
        }
        else
            animator.SetBool("IsMoving", false);

        animator.SetFloat("LastMoveX", lastMovement.x);
        animator.SetFloat("LastMoveY", lastMovement.y);
    }
}