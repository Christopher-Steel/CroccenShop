using UnityEngine;

public interface IClickObserver {
    void Notify(RaycastHit hit);
}
