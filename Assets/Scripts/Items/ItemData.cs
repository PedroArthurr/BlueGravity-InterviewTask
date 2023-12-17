using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Scriptable Objects/Create Menu Item", order = 100)]
public class ItemData : ScriptableObject
{
    [Header("Item info:")]
    public string itemName;
    public int price;
    public Sprite sprite;
    public Sprite previewSprite;
    public ItemType type;
    public string description;
    public SpriteLibraryAsset library;
}

public enum ItemType
{
    MISCELLANEOUS = 0,
    HAT = 1,
    OUTFIT = 2,
}
