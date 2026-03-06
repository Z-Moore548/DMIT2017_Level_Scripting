using System.Collections.Generic;
using UnityEngine;

public class InventoryContainer : MonoBehaviour
{
    private Dictionary<InventoryItemSO, InventoryItemData> containerInventory = new();
    public List<InventoryItemSO> startingInventory = new();
    public InventoryManager playerInventoryManager;

    void Start()
    {
        foreach(InventoryItemSO item in startingInventory)
        {
            if(!containerInventory.TryAdd(item, item.CreateRuntimeData()))
            {
                containerInventory[item].quantity++;
            }
        }
    }

    public void AddItemToContainer(InventoryItemSO itemToAdd_)
    {
        playerInventoryManager.RemoveItem(itemToAdd_);
        if(!containerInventory.TryAdd(itemToAdd_, itemToAdd_.CreateRuntimeData())){
            containerInventory[itemToAdd_].quantity++;
        }
    }

    public void AddItemToPlayerInventory(InventoryItemSO itemToAdd_)
    {
        if(containerInventory.TryGetValue(itemToAdd_, out InventoryItemData data))
        {
            if (containerInventory[itemToAdd_].quantity > 1)
            {
                containerInventory[itemToAdd_].quantity--;
            }
            else
            {
                containerInventory.Remove(itemToAdd_);
            }
            
        }
        playerInventoryManager.AddItem(itemToAdd_);
       
    }
}
