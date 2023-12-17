using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] private ItemData[] itemDatas;
    [SerializeField] private List<Item> items = new();

    private void Start()
    {
        GenerateItems();
    }

    public void GenerateItems()
    {
        foreach (var data in itemDatas)
        {
        }
    }

    public List<Item> GetItems()
    {
        return items;
    }
}