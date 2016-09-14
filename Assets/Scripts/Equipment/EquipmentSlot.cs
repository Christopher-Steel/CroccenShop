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
        if (IsFull()) {

        }
        return true;
    }
}
