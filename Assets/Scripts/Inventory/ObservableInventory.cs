using System.Collections.Generic;

public class ObservableInventory : Inventory {
    private List<IInventoryObserver> _observers = new List<IInventoryObserver>();

    public void AddObserver(IInventoryObserver observer) {
        _observers.Add(observer);
    }

    public void RemoveObserver(IInventoryObserver observer) {
        _observers.Remove(observer);
    }

    public override void Store(Pickupable item) {
        base.Store(item);
        _notifyObservers(item);
    }

    private void _notifyObservers(Pickupable item) {
        _observers.ForEach(x => x.Notify(item));
    }
}
