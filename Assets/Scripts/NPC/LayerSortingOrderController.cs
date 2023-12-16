using UnityEngine;

public class LayerSortingOrderController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] spriteRenderers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < spriteRenderers.Length; i++)
                spriteRenderers[i].sortingOrder = 20 + i;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = spriteRenderers.Length - 1; i >= 0; i--)
            {
                spriteRenderers[i].sortingOrder = i;
            }
        }
    }
}
