using UnityEngine;

public class Pickupable : AProximityInteractable {
    public override void Interact(GameObject source) {
        Inventory inv = source.GetComponent<Inventory>();

        if (inv != null
            && inv.HasSpace()) {
            inv.Store(this);
        }
    }
}
