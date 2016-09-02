using UnityEngine;

public class TriggerSpawner : ASpawner {
    public override void Interact(GameObject source) {
        Spawn();
    }
}
