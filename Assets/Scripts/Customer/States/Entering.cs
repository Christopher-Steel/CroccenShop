using UnityEngine;

namespace Customer {
    public class Entering : AState {
        public Entering(Agent customer) : base(customer) { }

        public override void OnEnter() {
            var nav = _customer.GetComponent<NavMeshAgent>();
            nav.destination = _customer.destination;
        }
    }
}