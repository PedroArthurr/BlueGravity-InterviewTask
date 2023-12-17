using UnityEngine;
using System.Collections.Generic;

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
        //Money thing
        playerInventory.AddItem(itemData);
        itemsForSale.Remove(itemData);
    }

    public void SellItem(ItemData itemData)
    {
        playerInventory.RemoveItem(itemData);
        itemsForSale.Add(itemData);
    }
}
