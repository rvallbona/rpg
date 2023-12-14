using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData itemData;
    private bool pickedUp = false;

    public void OnHandlePickUp()
    {
        if (!pickedUp)
        {
            InventoryManager._INVENTORY_MANAGER.Add(itemData);
            pickedUp = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnHandlePickUp();
        }
    }
}