using UnityEngine;
using System.Collections.Generic;

namespace Customer {
    public class Queue : MonoBehaviour {
        /// <summary>
        /// Distance and direction between queueing customers
        /// </summary>
        public Vector3 extendVector;

        private List<Agent> _queueing;
        private Vector3 _tail;

        public void Start() {
            _queueing = new List<Agent>();
            _tail = transform.position;
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
            if (_queueing.Count == 0) return null;
            if (_queueing.Count == 1) return _queueing[0];
            return _queueing[1];
        }
    }
}