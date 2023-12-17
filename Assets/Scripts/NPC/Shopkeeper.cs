using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour, IInteractable
{
    [SerializeField] private Shop shop;
    public void Interact()
    {
        Debug.Log("Interaction with: " + gameObject.name, gameObject);
        shop.InitializeShop();
    }
}
