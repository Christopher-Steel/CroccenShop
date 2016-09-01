namespace Customer {
    public abstract class AState : IState {
        protected Agent _customer;

        public AState(Agent customer) {
            _customer = customer;
        }

        public virtual void OnEnter() {}

        public virtual IState OnUpdate() {
            return null;
        }

        public virtual void OnExit() {}
    }
}