using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Customer {
    public class Queue : MonoBehaviour, IInventoryObserver {
        /// <summary>
        /// Distance and direction between queueing customers
        /// </summary>
        public Vector3 extendVector;
        public ObservableInventory counter;

        private List<Agent> _queueing;
        private Vector3 _tail;

        public void Start() {
            _queueing = new List<Agent>();
            _tail = transform.position;
            counter.AddObserver(this);
        }

        public void Enqueue(Agent joining) {
            joining.GoTo(_tail);
            _tail += extendVector;
            _queueing.Add(joining);
        }

        public void Dequeue(Agent leaving) {
            bool pastLeaver = false;
            foreach (Agent queueing in _queueing) {
                if (queueing == leaving) {
                    pastLeaver = true;
                    continue;
                }
                if (pastLeaver)
                    queueing.GoTo(queueing.destination - extendVector);
            }
            _queueing.Remove(leaving);
            _tail -= extendVector;
        }

        public Agent FirstWaitingFor() {
            return _queueing.FirstOrDefault();
        }

        public void Notify(Pickupable item) {
            Agent customer = FirstWaitingFor();
            if (customer == null) // Nobody queuing for this item yet
                return;
            counter.Take(item);
            item.Interact(customer.gameObject);
            customer.ChangeState(new Leaving(customer));
        }
    }
}