using UnityEngine;
using System.Collections.Generic;

public class ClickService : MonoBehaviour {
    public List<IClickObserver> observers = new List<IClickObserver>();

    public void AddObserver(IClickObserver observer) {
        observers.Add(observer);
    }

    public void RemoveObserver(IClickObserver observer) {
        observers.Remove(observer);
    }

    public void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;

            // Navigate to point clicked
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                foreach (IClickObserver observer in observers) {
                    observer.Notify(hit);
                }
            }
        }
    }
}
