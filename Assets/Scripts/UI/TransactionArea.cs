using UnityEngine;
using UnityEngine.EventSystems;

public class TransactionArea : MonoBehaviour, IDropHandler
{
    public Shop shop;
    public ShopUI shopUI;
    public PlayerInventory playerInventory;

    public void OnDrop(PointerEventData eventData)
    {
        ItemSlot droppedItemSlot = eventData.pointerDrag.GetComponent<ItemSlot>();
        if (droppedItemSlot != null)
        {
            if (playerInventory.ItemDatas.Contains(droppedItemSlot.Data))
            {
                shop.SellItem(droppedItemSlot.Data);
                Debug.Log("Sold: " + droppedItemSlot.Data.itemName);
            }
            else
            {
                shop.BuyItem(droppedItemSlot.Data);
                Debug.Log("Bought: " + droppedItemSlot.Data.itemName);
            }
            shopUI.OnShop();
        }
    }
}