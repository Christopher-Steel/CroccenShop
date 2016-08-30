using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMovement : MonoBehaviour, IClickObserver {
    public ClickService clickService = null;
    private NavMeshAgent _nav;
    
	public void Start() {
        Assert.IsNotNull(clickService);
        _nav = GetComponent<NavMeshAgent>();
        clickService.AddObserver(this);
	}
	
	public void Notify(RaycastHit hit) {
        _headTowardTarget(hit);
    }

    private void _headTowardTarget(RaycastHit hit) {
        // Set destination
        _nav.destination = hit.point;
        // Rotate to face target
        Vector3 target = hit.point;
        target.y = transform.position.y;
        transform.LookAt(target);
    }
}