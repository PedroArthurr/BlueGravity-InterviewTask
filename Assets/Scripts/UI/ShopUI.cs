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

    private void PopulateShopItems()
    {
        for (int i = shopItemsContainer.childCount - 1; i >= 0; i--)
            Destroy(shopItemsContainer.transform.GetChild(i).gameObject);
        for (int i = playerItemsContainer.childCount - 1; i >= 0; i--)
            Destroy(playerItemsContainer.transform.GetChild(i).gameObject);

        InitializeShopUI();
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
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
    }

    public void OnShop()
    {
        PopulateShopItems();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseShop();
        }
    }
}
