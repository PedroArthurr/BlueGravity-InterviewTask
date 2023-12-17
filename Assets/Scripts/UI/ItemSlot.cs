using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemValue;
    private bool isEquiped;

    private string description;
    private ItemData data;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 startPosition;
    private Transform originalParent;

    public ItemData Data { get => data; }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        originalParent = transform.parent;
    }

    public void Initialize(Sprite s, string n, string d, string v, ItemData i)
    {
        itemImage.sprite = s;
        itemName.text = n;
        itemValue.text = v;
        description = d;
        data = i;

        itemName.gameObject.SetActive(false);
        itemValue.gameObject.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = rectTransform.anchoredPosition;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent);
        canvasGroup.blocksRaycasts = true;
        StartCoroutine(ResetPosition());
    }

    private IEnumerator ResetPosition()
    {
        transform.parent.GetComponent<GridLayoutGroup>().enabled = false;
        yield return new WaitForEndOfFrame();
        transform.parent.GetComponent<GridLayoutGroup>().enabled = true;
        rectTransform.anchoredPosition = startPosition;
    }

    public void OnMouseHover()
    {
        itemName.gameObject.SetActive(true);
        itemValue.gameObject.SetActive(true);
    }

    public void OnMouseLeave()
    {
        itemName.gameObject.SetActive(false);
        itemValue.gameObject.SetActive(false);
    }

    public void DroppedOnValidArea()
    {
        isEquiped = !isEquiped;
        if (isEquiped)
            itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, .5f);
        else
            itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, 1);
    }
}