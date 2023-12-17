using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<ItemData> itemsForSale;
    [SerializeField] private ShopUI shopUI;
    [SerializeField] private PlayerInventory playerInventory;

    public void InitializeShop()
    {
        shopUI.OpenShop();
    }

    public void BuyItem(ItemData itemData)
    {
        if (playerInventory.currentBalance >= itemData.price)
        {
            playerInventory.currentBalance -= itemData.price; 
            playerInventory.AddItem(itemData);
            itemsForSale.Remove(itemData); 
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void SellItem(ItemData itemData)
    {
        playerInventory.currentBalance += itemData.price;
        playerInventory.RemoveItem(itemData);
        itemsForSale.Add(itemData); 
    }
}