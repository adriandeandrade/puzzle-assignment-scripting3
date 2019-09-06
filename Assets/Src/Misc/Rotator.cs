using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rotator : MonoBehaviour {

	public enum Axis {
		X,
		Y,
		Z
	}

	public Axis axis = Axis.Y;
	public float speed = 100f;

	// Use this for initialization
	void Start() {
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
		rb.isKinematic = true;
	}

	// Update is called once per frame
	void Update () {
		Quaternion rot = Quaternion.identity;
		switch (this.axis) {
			case Axis.X: rot = Quaternion.Euler(this.speed * Time.deltaTime, 0, 0); break;
			case Axis.Y: rot = Quaternion.Euler(0, this.speed * Time.deltaTime, 0); break;
			case Axis.Z: rot = Quaternion.Euler(0, 0, this.speed * Time.deltaTime); break;
		}
		this.transform.rotation *= rot;
	}
}
