using UnityEngine;

namespace Customer {
    public partial class Agent {
        [System.Serializable]
        public struct Info {
            public ObservableInventory Counter;
            public Transform Door;
        }
    }
}
