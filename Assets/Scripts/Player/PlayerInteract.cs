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
        IInteractable interactable = hit.transform.gameObject.GetComponent<IInteractable>();

        if (interactable != null) {
            _interactCoroutine = StartCoroutine(_waitAndInteract(interactable));
        }
    }

    private void _cancelPreviousInteractable() {
        if (_interactCoroutine != null) {
            StopCoroutine(_interactCoroutine);
            _interactCoroutine = null;
        }
    }

    private IEnumerator _waitAndInteract(IInteractable interactable) {
        do {
            yield return null; // Wait a frame
        } while (!interactable.CanInteractWith(gameObject));
        interactable.Interact(gameObject);
        _interactCoroutine = null;
    }
}
