using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Inventory))]
public class ItemSlotInteract : AInteractable {
    private Inventory slotInventory;

    public void Start() {
        InteractDistance = 1.4f;
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
