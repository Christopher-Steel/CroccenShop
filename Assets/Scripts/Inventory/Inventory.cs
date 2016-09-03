using UnityEngine;
using UnityEngine.Assertions;

public class Inventory : MonoBehaviour {
    public Transform carryTarget;
    public int capacity;

    public void Start() {
        Assert.IsTrue(capacity > 0);
    }

	public bool IsFull() {
        return carryTarget.childCount == capacity;
    }

    public bool IsEmpty() {
        return carryTarget.childCount == 0;
    }

    public virtual void Store(Pickupable item) {
        _attachItemToInventory(item);
    }

    public Pickupable TakeFirst() {
        Pickupable first = carryTarget.GetComponentInChildren<Pickupable>();

        _detachItemFromInventory(first);
        return first;
    }

    public void Take(Pickupable item) {
        Assert.IsTrue(item.transform.parent == carryTarget);
        _detachItemFromInventory(item);
    }

    private void _attachItemToInventory(Pickupable item) {
        item.transform.parent = carryTarget;
        item.transform.position = carryTarget.position;
        item.transform.rotation = carryTarget.rotation;
        item.boundingBox.enabled = false;
    }

    private void _detachItemFromInventory(Pickupable item) {
        item.boundingBox.enabled = true;
        item.gameObject.transform.parent = null;
    }
}
