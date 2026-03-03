using UnityEngine;

public class WeaponItemData: InventoryItemData
{
    public int weaponStrength, weaponDurability;

    public WeaponItemData(WeaponItemSO config)
    {
        this.config = config;
        this.flavourText = config.flavourText;
        this.itemName = config.itemName;
        this.icon = config.icon;
        this.weaponStrength = config.weaponStrength;
        this.weaponDurability = config.weaponDurability;
        quantity = 1;
    }
}
