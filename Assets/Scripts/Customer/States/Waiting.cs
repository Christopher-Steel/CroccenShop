namespace Customer {
    public class Waiting : AState, IInventoryObserver {
        public Waiting(Agent customer) : base(customer) {}

        public override void OnEnter() {
            _customer.info.Counter.AddObserver(this);
        }

        public override void OnExit() {
            _customer.info.Counter.RemoveObserver(this);
        }

        public void Notify(Pickupable item) {
            _customer.info.Counter.Take();
            item.Interact(_customer.gameObject);
        }
    }
}