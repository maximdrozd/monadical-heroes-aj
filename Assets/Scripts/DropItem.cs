using UnityEngine;

public class DropItem : MonoBehaviour
{
    public delegate void OnPickUp(Item item);
    public OnPickUp onPickUp;
    
    [SerializeField] private SpriteRenderer icon;
    [SerializeField] private SpriteRenderer background;
    public Item item;
    private void OnMouseDown()
    {
        onPickUp?.Invoke(item);
        Destroy(gameObject);
    }

    public void SetContent(Item contentItem)
    {
        item = contentItem;
        icon.sprite = contentItem.worldSprite;
    }
}
