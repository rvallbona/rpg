using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager _INVENTORY_MANAGER;

    public delegate void onInventoryChangedEvent();
    public event onInventoryChangedEvent onInventoryChangedEventCallback;

    private Dictionary<InventoryItemData, InventoryItem> _itemDirectionary;
    public List<InventoryItem> inventory;

    private void Awake()
    {
        if (_INVENTORY_MANAGER != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        _INVENTORY_MANAGER = this;

        inventory = new List<InventoryItem>();
        _itemDirectionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (onInventoryChangedEventCallback != null)
        {
            onInventoryChangedEventCallback.Invoke();
        }
    }

    public void Add(InventoryItemData itemData)
    {
        if (_itemDirectionary.TryGetValue(itemData, out InventoryItem value))
        {
            Debug.Log("Sum Stack In Item");

            value.AddStack();
        }
        else
        {
            Debug.Log("Add New Item");

            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            _itemDirectionary.Add(itemData, newItem);

            onInventoryChangedEventCallback.Invoke();
        }

        if (onInventoryChangedEventCallback != null)
        {
            onInventoryChangedEventCallback.Invoke();
        }
    }

    public void Remove(InventoryItemData itemData)
    {
        if (_itemDirectionary.TryGetValue(itemData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                _itemDirectionary.Remove(itemData);
            }
        }

        onInventoryChangedEventCallback.Invoke();
    }
}