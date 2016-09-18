using UnityEngine;

namespace Customer {
    public class Waiting : AState, IInventoryObserver {
        private Inventory _inventory;
        private float _impatienceTime;

        public Waiting(Agent customer) : base(customer) {}

        public override void OnEnter() {
            Debug.Log("Waiting");
            _customer.info.counter.AddObserver(this);
            _inventory = _customer.GetComponent<Inventory>();
            _impatienceTime = _customer.info.spawnTime + _customer.info.patience;
        }

        public override IState OnUpdate() {
            if (Time.timeSinceLevelLoad > _impatienceTime)
                return new Leaving(_customer);
            return null;
        }

        public override void OnExit() {
            _customer.info.counter.RemoveObserver(this);
        }

        public void Notify(Pickupable item) {
            if (!_inventory.IsFull()) {
                _customer.info.counter.Take(item);
                item.Interact(_customer.gameObject);
                _customer.ChangeState(new Leaving(_customer));
            }
        }
    }
}