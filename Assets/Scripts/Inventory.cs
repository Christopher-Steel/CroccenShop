using UnityEngine;

public class Inventory : MonoBehaviour {
    public Transform carryTransform;
    private Pickupable _slot = null;

	public bool HasSpace() {
        return _slot == null;
    }

    public void Store(Pickupable item) {
        _slot = item;
        _attachItemToInventory(item);
    }

    public Pickupable Take() {
        Pickupable item = _slot;

        _slot = null;
        _detachItemFromInventory(item);
        return item;
    }

    private void _attachItemToInventory(Pickupable item) {
        item.gameObject.transform.parent = transform;
        item.gameObject.transform.localPosition = carryTransform.localPosition;
        item.gameObject.transform.localRotation = carryTransform.localRotation;
    }

    private void _detachItemFromInventory(Pickupable item) {
        item.gameObject.transform.parent = null;
    }
}
