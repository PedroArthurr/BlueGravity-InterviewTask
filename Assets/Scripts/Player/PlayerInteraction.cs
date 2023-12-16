using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 1.5f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;

    private PlayerController controller;
    private IInteractable interactableInRange;

    private void Start() => controller = GetComponentInParent<PlayerController>();

    private void Update()
    {
        CheckForInteractable();

        if (Input.GetKeyDown(interactionKey) && interactableInRange != null)
            interactableInRange.Interact();
    }

    private void CheckForInteractable()
    {
        Vector2 direction = GetFacingDirection();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, interactionDistance, interactableLayer);
        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
            {
                interactableInRange = interactable;
                OnPotentialInteraction();
            }
        }
        else
        {
            interactableInRange = null;
        }
    }

    private void OnPotentialInteraction()
    {

    }

    private Vector2 GetFacingDirection()
    {
        return controller.LastDirection;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        if (controller != null)
        {
            Vector3 direction = controller.LastDirection;
            Gizmos.DrawLine(transform.position, transform.position + direction * interactionDistance);
        }
    }
#endif
}
