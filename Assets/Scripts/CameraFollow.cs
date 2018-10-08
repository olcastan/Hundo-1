using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform Target;
    public float Speed;
	private Vector3 camTarget;

    public void Update() {
		camTarget = Target.position;
		camTarget.z = -1.5f;
        transform.position = Vector3.Lerp(transform.position, camTarget, (Speed * Time.deltaTime));
    }
}
