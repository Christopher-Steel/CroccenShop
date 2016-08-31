using UnityEngine;
using UnityEngine.Assertions;

public class Inventory : MonoBehaviour {
    public Transform carryTransform;
    private Pickupable _slot = null;

	public bool HasSpace() {
        return _slot == null;
    }

    public virtual void Store(Pickupable item) {
        _slot = item;
        _attachItemToInventory(item);
    }

    public Pickupable Take() {
        Assert.IsNotNull(_slot);
        Pickupable item = _slot;

        _slot = null;
        _detachItemFromInventory(item);
        return item;
    }

    private void _attachItemToInventory(Pickupable item) {
        item.gameObject.transform.parent = transform;
        item.gameObject.transform.position = carryTransform.position;
        item.gameObject.transform.rotation = carryTransform.rotation;
    }

    private void _detachItemFromInventory(Pickupable item) {
        item.gameObject.transform.parent = null;
    }
}
