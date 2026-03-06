using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Dictionary<InventoryItemSO, InventoryItemData> inventory = new Dictionary<InventoryItemSO, InventoryItemData>();
    public InventoryItemSO[] startingInventory;
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
       foreach(InventoryItemSO item in startingInventory)
        {
            AddItem(item);
        }

    }
    public void AddItem(InventoryItemSO itemToAdd_)
    {
        if(!inventory.TryAdd(itemToAdd_, itemToAdd_.CreateRuntimeData())){
            inventory[itemToAdd_].quantity++;
        }
    }

    public void RemoveItem(InventoryItemSO itemToRemove_)
    {
        if(inventory.TryGetValue(itemToRemove_, out InventoryItemData data))
        {
            if (inventory[itemToRemove_].quantity > 1)
            {
                inventory[itemToRemove_].quantity--;
                return;
            }
            inventory.Remove(itemToRemove_);
        }
       
    }
}
