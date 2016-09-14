using UnityEngine;

/// <summary>
/// This class serves as a dispatcher for all the
/// EquipmentSlots that are on its children.
/// </summary>
public class EquipmentOrganiser : MonoBehaviour {
    private EquipmentSlot[] _slots;

    void Start() {
        _slots = GetComponentsInChildren<EquipmentSlot>();
    }

    /// <summary>
    /// Look for an empty EquipmentSlot of the right
    /// type, Equip the Equipment in it and return true.
    /// If no slot is found or none are empty, nothing
    /// happens and this function returns false. 
    /// </summary>
    void Equip(Equipment item) {
        foreach (EquipmentSlot slot in _slots) {
            if (slot.type == item.type && slot.IsEmpty()) {
                slot.Equip(item);
            }
        }
    }
}
