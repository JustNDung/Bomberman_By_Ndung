using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        ExtraBomb,
        BlastRadius,
        SpeedIncrease
    }
    public ItemType itemType;

    private void OnItemPickup(GameObject player)
    {
        switch (itemType)
        {
            case ItemType.ExtraBomb:
                player.GetComponent<BombController>().AddBomb();
                break;
            case ItemType.BlastRadius:
                player.GetComponent<BombController>().explosionRadius++;
                break;
            case ItemType.SpeedIncrease:
                player.GetComponent<MovementController>().movementSpeed++;
                break;
        }
        
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnItemPickup(collision.gameObject);
        }
    }
}
