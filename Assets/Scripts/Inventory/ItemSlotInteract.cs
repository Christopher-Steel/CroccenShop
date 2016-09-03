using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Inventory))]
public class ItemSlotInteract : AProximityInteractable {
    private Inventory targetInventory;

    public override void Start() {
        base.Start();
        targetInventory = GetComponent<Inventory>();
    }

    public override void Interact(GameObject source) {
        Inventory sourceInventory = source.GetComponent<Inventory>();

        Assert.IsNotNull(sourceInventory);
        if (sourceInventory.IsEmpty()) {
            sourceInventory.Store(targetInventory.TakeFirst());
        } else if (!targetInventory.IsFull()) {
            targetInventory.Store(sourceInventory.TakeFirst());
        }
    }
}
