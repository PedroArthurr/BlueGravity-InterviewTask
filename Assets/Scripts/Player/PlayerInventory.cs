using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerInventory : MonoBehaviour
{
    public int currentBalance = 1000;

    [SerializeField] private SpriteLibrary hat;
    [SerializeField] private SpriteLibrary outfit;
    [SerializeField] private ItemData equippedHat;
    [SerializeField] private ItemData equippedOutfit;

    [SerializeField] private List<ItemData> items = new();

    private InventoryUI inventoryUI;

    public ItemData EquippedOutfit { get => equippedOutfit; set => equippedOutfit = value; }
    public ItemData EquippedHat { get => equippedHat; set => equippedHat = value; }
    public List<ItemData> ItemDatas { get => items; }
    public InventoryUI InventoryUI { set => inventoryUI = value; }

    public void AddItem(ItemData item)
    {
        items.Add(item);
        inventoryUI.UpdateUI();
    }

    public void RemoveItem(ItemData item)
    {
        if (item == equippedHat || item == equippedOutfit)
        {
            UnequipItem(item);
        }
        items.Remove(item);
        inventoryUI.UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!GameManager.instance.playerCanInteract)
                return;
            inventoryUI.SetInventoryPanel();
        }
    }

    public void OnEquippedItem()
    {
        inventoryUI.UpdateUI();
        if (equippedHat != null)
            hat.spriteLibraryAsset = equippedHat.library;
        if (equippedOutfit != null)
            outfit.spriteLibraryAsset = equippedOutfit.library;
    }

    public void UnequipItem(ItemData item)
    {
        if (item == equippedHat)
        {
            equippedHat = null;
            hat.spriteLibraryAsset = null;
            hat.GetComponent<SpriteRenderer>().sprite = null;
        }
        else if (item == equippedOutfit)
        {
            equippedOutfit = null;
            outfit.spriteLibraryAsset = null;
            outfit.GetComponent<SpriteRenderer>().sprite = null;
        }
        OnEquippedItem();
    }
}