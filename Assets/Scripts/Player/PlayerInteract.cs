using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

class PlayerInteract : MonoBehaviour, IClickObserver {
    public ClickService clickService = null;
    private Coroutine _interactCoroutine;

    public void Start() {
        Assert.IsNotNull(clickService);
        _interactCoroutine = null;
        clickService.AddObserver(this);
    }

    public void Notify(RaycastHit hit) {
        _cancelPreviousInteractable();
        _checkForInteractable(hit);
    }

    private void _checkForInteractable(RaycastHit hit) {
        AInteractable interactable = hit.transform.gameObject.GetComponent<AInteractable>();

        if (interactable != null) {
            _interactCoroutine = StartCoroutine(_waitToReachInteractable(interactable));
        }
    }

    private void _cancelPreviousInteractable() {
        if (_interactCoroutine != null) {
            StopCoroutine(_interactCoroutine);
            _interactCoroutine = null;
        }
    }

    private IEnumerator _waitToReachInteractable(AInteractable interactable) {
        float distance;
        Vector3 differenceVector;

        do {
            yield return null;
            differenceVector = interactable.transform.position - transform.position;
            differenceVector.y = 0; // ignoring Y axis for proximity
            distance = differenceVector.magnitude;
            Debug.Log(string.Format("distance to interact: {0} < {1}", distance, interactable.InteractDistance));
        } while ((distance) > interactable.InteractDistance);
        interactable.Interact(gameObject);
        _interactCoroutine = null;
    }
}