using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

namespace Customer {
    public class Factory : MonoBehaviour {
        public Agent.Info info;
        public GameObject customerTemplate;

        public GameObject Create() {
            var customer = Instantiate(customerTemplate);
            var inventory = customer.GetComponent<Inventory>();
            var agent = customer.GetComponent<Agent>();

            Assert.IsNotNull(inventory, "customerTemplate must have an Inventory");
            Assert.IsNotNull(agent, "customerTemplate must have an Agent");

            agent.info = info;
            agent.info.spawnTime = Time.timeSinceLevelLoad;
            customer.transform.position = info.door.position;
            agent.ChangeState(new Entering(agent));
            return customer;
        }

        public IEnumerator Start() {
            Create();
            yield return new WaitForSeconds(3);
            Create();
        }
    }
}