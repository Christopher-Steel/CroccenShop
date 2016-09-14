using UnityEngine;
using System.Collections;

/// <summary>
/// A single slot inventory that can only store
/// Equipment of a single type
/// </summary>
public class EquipmentSlot : Inventory {
    public string type;

    public EquipmentSlot() {
        capacity = 1;
    }

    public bool Equip(Equipment item) {
        if (item.type != type) {
            Debug.LogError(string.Format("Can't equip {0} in {1} slot", item.type, type));
            return false;
        }
        if (IsFull()) {
            Debug.LogWarning(string.Format("Attempted to equip {0} in occupied slot", type));
            return false;
        }
        Store(item);
        return true;
    }
}
