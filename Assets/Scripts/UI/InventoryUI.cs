using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private ItemSlot itemSlotPrefab;
    [SerializeField] private Image equippedHat;
    [SerializeField] private Image equippedOutfit;

    [SerializeField] private TMP_Text date;
    [SerializeField] private TMP_Text time;
    private void Awake()
    {
        UpdateUI();
        playerInventory.InventoryUI = this;
    }

    public void SetInventoryPanel()
    {
        container.SetActive(!container.activeInHierarchy);
        playerController.CanMove = !container.activeInHierarchy;
    }

    public void UpdateUI()
    {
        for (int i = inventoryPanel.transform.childCount - 1; i >= 0; i--)
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);

        foreach (ItemData item in playerInventory.ItemDatas)
        {
            var slot = Instantiate(itemSlotPrefab, inventoryPanel.transform);
            slot.Initialize(item.sprite, item.itemName, item.description, item.price.ToString(), item);
        }

        if (playerInventory.EquippedHat != null)
        {
            equippedHat.gameObject.SetActive(true);

            equippedHat.sprite = playerInventory.EquippedHat.previewSprite;
        }
        else
        {
            equippedHat.sprite = null;
            equippedHat.gameObject.SetActive(false);
        }

        if (playerInventory.EquippedOutfit != null)
        {
            equippedOutfit.gameObject.SetActive(true);
            equippedOutfit.sprite = playerInventory.EquippedOutfit.previewSprite;
        }
        else
        {
            equippedOutfit.sprite = null;
            equippedOutfit.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        //Current date-time because why not? :P
        var dateTime = System.DateTime.Now;
        date.text = $"{dateTime.Day}.{dateTime:ddd}";
        time.text = dateTime.ToString("HH:mm");
    }
}
