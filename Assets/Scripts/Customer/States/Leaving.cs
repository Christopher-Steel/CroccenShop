using UnityEngine;

namespace Customer {
    public class Leaving : AState {
        public Leaving(Agent customer) : base(customer) { }

        public override void OnEnter() {
            Debug.Log("Leaving");
            _customer.info.queue.Dequeue(_customer);
            _customer.GoTo(_customer.info.door.position);
        }
    }
}