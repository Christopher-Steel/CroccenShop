using UnityEngine;

public abstract class ASpawner : AProximityInteractable {
    public Transform spawnTarget;
    public GameObject subject; // Object to spawn (by cloning)

    public virtual GameObject CreateObject() {
        return Instantiate(subject);
    }

    public virtual void Spawn() {
        if (!_hasSpace()) return;
        var spawnee = CreateObject();

        spawnee.transform.position = spawnTarget.position;
        spawnee.transform.rotation = spawnTarget.rotation;
        spawnee.transform.parent = spawnTarget;
    }

    private bool _hasSpace() {
        return spawnTarget.childCount == 0;
    }
}
