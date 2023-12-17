using UnityEngine;

public class Shopkeeper : MonoBehaviour, IInteractable
{
    [SerializeField] private Shop shop;
    [SerializeField] private GameObject interactionIcon;

    public void Interact()
    {
        Debug.Log("Interaction with: " + gameObject.name, gameObject);
        shop.InitializeShop();
    }

    public void ShowInteractionIcon()
    {
        interactionIcon.SetActive(true);
    }

    public void HideInteractionIcon()
    {
        interactionIcon.SetActive(false);
    }
}