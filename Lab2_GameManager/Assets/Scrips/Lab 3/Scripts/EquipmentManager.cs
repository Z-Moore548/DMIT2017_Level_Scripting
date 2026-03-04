using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public Dictionary<EquipmentSlot, InventoryItemData> equipmentDictionary = new();
    public static EquipmentManager instance;
    public event Action<Dictionary<EquipmentSlot, InventoryItemData>> onEquip;

    private void Awake()
    {
        if (instance == null) instance = this;
        InitializeEquipment();
    }

    public void InitializeEquipment()
    {
        equipmentDictionary.Add(EquipmentSlot.HELM, null);
        equipmentDictionary.Add(EquipmentSlot.CHEST, null);
        equipmentDictionary.Add(EquipmentSlot.ARMS, null);
        equipmentDictionary.Add(EquipmentSlot.BOOTS, null);
        equipmentDictionary.Add(EquipmentSlot.WEAPON, null);

    }

    public void EquipItem(InventoryItemData itemToEquip)
    {
        if(itemToEquip is ArmorItemData armor)
        {
            equipmentDictionary[armor.equipmentSlot] = armor;
            Debug.Log(equipmentDictionary[armor.equipmentSlot].itemName + " was equipped");
        }

        else if (itemToEquip is WeaponItemData weapon) 
        {
            equipmentDictionary[EquipmentSlot.WEAPON] = weapon;
            Debug.Log(equipmentDictionary[EquipmentSlot.WEAPON].itemName + " was equipped");
        }
        onEquip?.Invoke(equipmentDictionary);
    }

    
}
