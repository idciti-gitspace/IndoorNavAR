using UnityEngine;
using UnityEngine.AI;

public class NavigationController : MonoBehaviour {

    public Vector3 TargetPosition { get; set; } = Vector3.zero;

    public NavMeshPath CalculatedPath { get; private set; }

    private void Start() {
        CalculatedPath = new NavMeshPath();
    }

    public void NewPath(Vector3 target) {
        if (target != Vector3.zero) {
            NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, CalculatedPath);
        }
    }
}
