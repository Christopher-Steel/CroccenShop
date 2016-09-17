using UnityEngine;

namespace Customer {
    public class Leaving : AState {
        public Leaving(Agent customer) : base(customer) { }

        public override void OnEnter() {
            Debug.Log("Leaving");
            var nav = _customer.GetComponent<NavMeshAgent>();
            _customer.destination = _customer.info.door.position;
            nav.destination = _customer.destination;

        }
    }
}