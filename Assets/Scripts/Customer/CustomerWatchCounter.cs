using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class CustomerWatchCounter : MonoBehaviour, IInventoryObserver {
    public ObservableInventory Counter;

    public void Start() {
        Counter.AddObserver(this);
    }

    public void Notify(Pickupable item) {
        Debug.Log("Notified");
        Counter.Take();
        item.Interact(gameObject);
    }
}
