using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<InventoryItemSO, InventoryItemData> inventory = new Dictionary<InventoryItemSO, InventoryItemData>();
    public InventoryItemSO tmp;
    void Start()
    {
        AddItem(tmp);
        AddItem(tmp);

        Debug.Log(inventory[tmp].quantity);
    }
    public void AddItem(InventoryItemSO itemToAdd)
    {
        if(!inventory.TryAdd(itemToAdd, itemToAdd.CreateRuntimeData()))
        {
            inventory[itemToAdd].quantity++;
        }
    }
    public void RemoveItem(InventoryItemSO itemToRemove)
    {
        //if(inventory.TryGetValue(itemToRemove, out ))
        if(inventory[itemToRemove].quantity > 1)
        {
            inventory[itemToRemove].quantity--;
            return;
        }
        inventory.Remove(itemToRemove);
    }
}
