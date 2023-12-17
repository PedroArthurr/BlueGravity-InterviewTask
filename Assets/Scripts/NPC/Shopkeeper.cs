using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Item> availableItems = new();
    public void Interact()
    {
        Debug.Log("Interaction with: " + gameObject.name, gameObject);
    }
}
