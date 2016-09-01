using UnityEngine;

namespace Customer {
    [RequireComponent(typeof(Inventory))]
    public partial class Agent : MonoBehaviour {
        public Info info;
        public IState currentState { get; private set; }

        void Start() {
            _changeState(new Waiting(this));
        }

        void Update() {
            if (currentState == null) return;
            IState nextState;

            nextState = currentState.OnUpdate();
            if (nextState != null) {
                _changeState(nextState);
            }
        }

        private void _changeState(IState nextState) {
            if (currentState != null) {
                currentState.OnExit();
            }
            currentState = nextState;
            currentState.OnEnter();
        }
    }
}