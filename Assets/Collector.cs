using UnityEngine;
using System.Collections.Generic;

public class Collector : MonoBehaviour {
    public List<GameObject> collected;

    void Start() {
        collected = new List<GameObject>();
    }

    void OnTriggerEnter(Collider other) {
        collected.Add(other.gameObject);
        other.gameObject.SetActive(false);
    }
}
