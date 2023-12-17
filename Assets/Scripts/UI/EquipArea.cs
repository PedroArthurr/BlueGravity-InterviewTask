using UnityEngine;
using UnityEngine.EventSystems;

public class EquipArea : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private ItemType equipType;

    public void OnDrop(PointerEventData eventData)
    {
        ItemSlot droppedItemSlot = eventData.pointerDrag.GetComponent<ItemSlot>();
        if (droppedItemSlot != null)
        {
            EquipItem(droppedItemSlot.Data);
            droppedItemSlot.DroppedOnValidArea();
        }
    }

    private void EquipItem(ItemData itemData)
    {
        switch (equipType)
        {
            case ItemType.HAT:
                inventory.EquippedHat = itemData;
                break;

            case ItemType.OUTFIT:
                inventory.EquippedOutfit = itemData;
                break;
        }

        inventory.OnEquippedItem();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UnequipItem();
    }

    private void UnequipItem()
    {
        switch (equipType)
        {
            case ItemType.HAT:
                if (inventory.EquippedHat != null)
                {
                    inventory.UnequipItem(inventory.EquippedHat);
                    inventory.EquippedHat = null;
                }
                break;

            case ItemType.OUTFIT:
                if (inventory.EquippedOutfit != null)
                {
                    inventory.UnequipItem(inventory.EquippedOutfit);
                    inventory.EquippedOutfit = null;
                }
                break;
        }

        inventory.OnEquippedItem();
    }
}