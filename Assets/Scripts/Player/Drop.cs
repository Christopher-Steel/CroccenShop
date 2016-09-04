using System;
using UnityEngine;

namespace Player {
    [RequireComponent(typeof(Inventory))]
    [RequireComponent(typeof(Collider))]
    public class Drop : MonoBehaviour, IInteractable {
        private Inventory _inventory;

        public void Start() {
            _inventory = GetComponent<Inventory>();
        }

        public bool CanInteractWith(GameObject other) {
            return other == gameObject; // Can only interact with self
        }

        public void Interact(GameObject source) {
            if (_inventory.IsEmpty()) return;

            Pickupable dropped = _inventory.TakeFirst();

            dropped.transform.position = new Vector3(
                transform.position.x,
                dropped.transform.localScale.y / 2,
                transform.position.z
            );
            // TODO replace this with dropping the croccen facing
            // the same direction as the player
            dropped.transform.rotation = Quaternion.identity;
        }
    }
}
