using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventoryPanelBG;
    [SerializeField] private ItemSlot itemSlotPrefab;
    [SerializeField] private Image equippedHat;
    [SerializeField] private Image equippedOutfit;

    [SerializeField] private TMP_Text userName;
    [SerializeField] private TMP_Text balance;
    [SerializeField] private TMP_Text date;
    [SerializeField] private TMP_Text time;

    private void Awake()
    {
        playerInventory.InventoryUI = this;
        UpdateUI();
    }

    public void SetInventoryPanel()
    {
        if (GameManager.instance.playerCanInteract)
        {
            SetPanel(true);
        }
        else
        {
            SetPanel(false);
        }

        playerController.CanMove = !container.activeInHierarchy;

        userName.text = GameManager.instance.userName;
    }

    public void SetPanel(bool state)
    {
        container.SetActive(state);
        inventoryPanelBG.SetActive(state);

        GameManager.instance.playerCanInteract = !state;
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

        balance.text = playerInventory.currentBalance.ToString();
    }

    private void Update()
    {
        date.text = $"{GameManager.instance.dateTime.Day}.{GameManager.instance.dateTime:ddd}";
        time.text = GameManager.instance.dateTime.ToString("HH:mm");
    }
}