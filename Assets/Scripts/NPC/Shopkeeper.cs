using UnityEngine;

public class Shopkeeper : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interaction with: " + gameObject.name, gameObject);
    }
}
