using UnityEngine;

namespace Customer {
    public class Entering : AState {
        private const float ARRIVED_DISTANCE = 0.6f;

        public Entering(Agent customer) : base(customer) { }

        public override void OnEnter() {
            Debug.Log("Entering");
            var nav = _customer.GetComponent<NavMeshAgent>();
            nav.destination = _customer.destination;
        }

        public override IState OnUpdate() {
            float distance = Helpers.Distance2D.Between(_customer.gameObject, _customer.destination);
            if (distance < ARRIVED_DISTANCE)
                return new Waiting(_customer);
            return null;
        }
    }
}