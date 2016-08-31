using UnityEngine;
using System.Collections.Generic;

public class ClickService : MonoBehaviour {
    private List<IClickObserver> _observers = new List<IClickObserver>();

    public void AddObserver(IClickObserver observer) {
        _observers.Add(observer);
    }

    public void RemoveObserver(IClickObserver observer) {
        _observers.Remove(observer);
    }

    public void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;

            // Navigate to point clicked
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                _notifyObservers(hit);
            }
        }
    }

    private void _notifyObservers(RaycastHit hit) {
        _observers.ForEach(x => x.Notify(hit));
    }
}
