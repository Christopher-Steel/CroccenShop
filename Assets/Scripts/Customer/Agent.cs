using UnityEngine;

namespace Customer {
    [RequireComponent(typeof(Inventory))]
    public partial class Agent : MonoBehaviour {
        public Info info;
        public IState currentState { get; private set; }
        public Vector3 destination;

        void Start() {
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
    }
}