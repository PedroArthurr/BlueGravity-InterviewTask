using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerAnimationController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float tileSize = 0.5f;
    [SerializeField] private LayerMask obstacleLayer;

    private PlayerAnimationController animationController;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lastDirection = Vector2.down;
    private bool isMoving = false;
    private bool canMove = true;

    public Vector2 Movement { get => movement; }
    public Vector2 LastDirection { get => lastDirection; }
    public bool CanMove { set => canMove = value; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationController = GetComponent<PlayerAnimationController>();
    }

    private void Update()
    {
        if (!isMoving && canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (movement != Vector2.zero)
            {
                lastDirection = movement.normalized;
                Vector2 moveDirection = new(Mathf.Round(movement.x), Mathf.Round(movement.y));

                if (IsPathClear(moveDirection))
                    StartCoroutine(MoveToNextTile(moveDirection));
            }
        }

        animationController.UpdateMovementAnimation(movement);
    }

    private IEnumerator MoveToNextTile(Vector2 direction)
    {
        isMoving = true;

        Vector3 startPosition = rb.position;
        Vector3 endPosition = RoundToTile(startPosition + new Vector3(direction.x, direction.y, 0) * tileSize, tileSize);

        float elapsedTime = 0;
        float journeyLength = Vector3.Distance(startPosition, endPosition);
        while (elapsedTime < journeyLength / moveSpeed)
        {
            rb.MovePosition(Vector3.Lerp(startPosition, endPosition, (elapsedTime * moveSpeed) / journeyLength));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rb.MovePosition(endPosition);
        isMoving = false;
    }

    private Vector3 RoundToTile(Vector3 position, float size)
    {
        return new Vector3(
            Mathf.Round(position.x / size) * size,
            Mathf.Round(position.y / size) * size,
            position.z
        );
    }

    private bool IsPathClear(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, tileSize, obstacleLayer);
        return hit.collider == null;
    }
}
