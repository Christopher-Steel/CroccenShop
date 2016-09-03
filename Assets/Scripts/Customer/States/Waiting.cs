namespace Customer {
    public class Waiting : AState, IInventoryObserver {
        private Inventory _inventory;

        public Waiting(Agent customer) : base(customer) {}

        public override void OnEnter() {
            _customer.info.counter.AddObserver(this);
            _inventory = _customer.GetComponent<Inventory>();
        }

        public override void OnExit() {
            _customer.info.counter.RemoveObserver(this);
        }

        public void Notify(Pickupable item) {
            if (!_inventory.IsFull()) {
                _customer.info.counter.Take(item);
                item.Interact(_customer.gameObject);
            }
        }
    }
}