using UnityEngine;

public class ArmorItemData: InventoryItemData
{
    public int ArmorRating;
    public ArmorSlot armorSlot;

    public ArmorItemData(ArmourItemSO config)
    {
        this.config = config;
        this.flavourText = config.flavourText;
        this.itemName = config.itemName;
        this.icon = config.icon;
        this.armorSlot = config.armorSlot;
        this.ArmorRating = config.ArmorRating;
        quantity = 1;
    }
}
