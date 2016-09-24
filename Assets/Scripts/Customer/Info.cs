using UnityEngine;

namespace Customer {
    public partial class Agent {
        [System.Serializable]
        public struct Info {
            public ObservableInventory counter;
            public Transform door;
            public Queue queue;
            public IRequirement[] requirements;
            public float spawnTime;
            public float patience;
        }
    }
}
