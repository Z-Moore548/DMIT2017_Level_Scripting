using UnityEngine;

[CreateAssetMenu(fileName = "WeaponItemSO", menuName = "Inventory System/WeaponItemSO")]
public class WeaponItemSO : InventoryItemSO
{
    public int weaponStrength, weaponDurability;

    public override InventoryItemData CreateRuntimeData()
    {
        return new WeaponItemData(this);
    }
}
