using UnityEngine;
using UnityEngine.EventSystems;

public class EquipArea : MonoBehaviour, IDropHandler
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
        print(itemData.description);
        switch(equipType)
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
}
