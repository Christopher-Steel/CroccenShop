namespace Customer {
    public interface IState {
        void OnEnter();
        IState OnUpdate();
        void OnExit();
    }
}
