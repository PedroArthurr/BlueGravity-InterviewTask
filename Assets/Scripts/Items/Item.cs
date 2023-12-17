using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemData itemData;

    public ItemData ItemData { get => itemData; }

    public void Initialize(ItemData data)
    {
        itemData = data;
    }
}
