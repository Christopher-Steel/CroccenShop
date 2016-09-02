using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Inventory))]
public class ItemSlotInteract : AProximityInteractable {
    private Inventory slotInventory;

    public override void Start() {
        base.Start();
        slotInventory = GetComponent<Inventory>();
    }

    public override void Interact(GameObject source) {
        Inventory sourceInventory = source.GetComponent<Inventory>();

        Assert.IsNotNull(sourceInventory);
        if (slotInventory.HasSpace()
            && !sourceInventory.HasSpace()) {
            slotInventory.Store(sourceInventory.Take());
        }
    }
}
