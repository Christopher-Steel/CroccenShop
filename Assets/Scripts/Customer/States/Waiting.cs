using UnityEngine;

namespace Customer {
    public class Waiting : AState {
        private float _impatienceTime;

        public Waiting(Agent customer) : base(customer) {}

        public override void OnEnter() {
            Debug.Log("Waiting");
            _impatienceTime = _customer.info.spawnTime + _customer.info.patience;
        }

        public override IState OnUpdate() {
            if (Time.timeSinceLevelLoad > _impatienceTime)
                return new Leaving(_customer);
            return null;
        }
    }
}