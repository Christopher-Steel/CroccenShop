using UnityEngine;

public class Pickupable : AInteractable {
    public override void Interact(GameObject source) {
        Inventory inv = source.GetComponent<Inventory>();

        if (inv != null
            && inv.HasSpace()) {
            inv.Store(this);
        }
    }
}
