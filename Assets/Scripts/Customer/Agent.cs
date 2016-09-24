using UnityEngine;
using UnityEngine.Assertions;
using System.Linq;

namespace Customer {
    [RequireComponent(typeof(Inventory))]
    public partial class Agent : MonoBehaviour {
        public Info info;
        public IState currentState { get; private set; }
        public Vector3 destination;

        private NavMeshAgent _nav;

        void Start() {
            _nav = GetComponent<NavMeshAgent>();
            Assert.IsNotNull(_nav);
            ChangeState(new Entering(this));
        }

        void Update() {
            if (currentState == null) return;
            IState nextState;

            nextState = currentState.OnUpdate();
            if (nextState != null) {
                ChangeState(nextState);
            }
        }

        public void ChangeState(IState nextState) {
            if (currentState != null) {
                currentState.OnExit();
            }
            currentState = nextState;
            currentState.OnEnter();
        }

        public void GoTo(Vector3 destination) {
            this.destination = destination;
            _nav.destination = this.destination;
        }

        public bool Wants(GameObject croccen) {
            if (info.requirements == null)
                return true;
            return info.requirements.All(r => r.IsMet(croccen));
        }
    }
}