using UnityEngine;

public interface IInteractable {
    bool CanInteractWith(GameObject other);
    void Interact(GameObject source);
}
