using UnityEngine;

[CreateAssetMenu(fileName = "ArmourItemSO", menuName = "Inventory System/ArmourItemSO")]
public class ArmourItemSO : InventoryItemSO
{
    public int ArmorRating;
    public ArmorSlot armorSlot;

    public override InventoryItemData CreateRuntimeData()
    {
        return new ArmorItemData(this);
    }
}

public enum ArmorSlot
{
    HELM, CHEST, LEGS, BOOTS
}
