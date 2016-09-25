using UnityEngine;
using System.Collections.Generic;

using Customer.Requirements;

namespace Level {
    public partial class CustomerScheduler : MonoBehaviour {
        public Customer.Factory factory;
        public Queue<Visit> visits;

        void Start() {
            visits = new Queue<Visit>(new[] {
                new Visit(4, new[] { new HasColor(Croccen.Color.Green) }),
                new Visit(6),
                new Visit(7, new[] { new HasColor(Croccen.Color.Green) }),
                new Visit(8, new[] { new HasSize(Croccen.Size.Adult) }),
            });
        }

        void Update() {
            if (visits.Count == 0) {
                enabled = false;
                return;
            }
            if (visits.Peek().time < Time.timeSinceLevelLoad) {
                var visit = visits.Dequeue();
                factory.Create(visit.requirements);
            }
        }
    }
}
