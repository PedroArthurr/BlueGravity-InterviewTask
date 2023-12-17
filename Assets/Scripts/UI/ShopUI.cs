using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [Header("Shop Setup")]
    [SerializeField] private GameObject shopPanel;

    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private Transform shopItemsContainer;
    [SerializeField] private Transform playerItemsContainer;
    [SerializeField] private Shop shop;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private PlayerController controller;
    [SerializeField] private TMP_Text userBalance;

    private void PopulateShopItems()
    {
        for (int i = shopItemsContainer.childCount - 1; i >= 0; i--)
            Destroy(shopItemsContainer.transform.GetChild(i).gameObject);
        for (int i = playerItemsContainer.childCount - 1; i >= 0; i--)
            Destroy(playerItemsContainer.transform.GetChild(i).gameObject);

        InitializeShopUI();

        userBalance.text = $"{GameManager.instance.userName}'s current balance: <color=#FFFF00>{playerInventory.currentBalance}</color>";
    }

    private void InitializeShopUI()
    {
        foreach (var itemData in shop.itemsForSale)
        {
            GameObject slotObj = Instantiate(itemSlotPrefab, shopItemsContainer);
            ItemSlot itemSlot = slotObj.GetComponent<ItemSlot>();
            if (itemSlot != null)
            {
                itemSlot.Initialize(itemData.sprite, itemData.itemName, itemData.description, itemData.price.ToString(), itemData);
            }
        }
        foreach (var itemData in playerInventory.ItemDatas)
        {
            GameObject slotObj = Instantiate(itemSlotPrefab, playerItemsContainer);
            ItemSlot itemSlot = slotObj.GetComponent<ItemSlot>();
            if (itemSlot != null)
            {
                itemSlot.Initialize(itemData.sprite, itemData.itemName, itemData.description, itemData.price.ToString(), itemData);
            }
        }
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
        PopulateShopItems();
        controller.CanMove = false;
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);

        GameManager.instance.playerCanInteract = true;
        controller.CanMove = true;
    }

    public void OnShop()
    {
        PopulateShopItems();
    }
}