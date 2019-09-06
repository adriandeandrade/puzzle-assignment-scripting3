using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shimmy : MonoBehaviour {

	public float distance = 1f;

	private Vector3 originalPosition;

	// Use this for initialization
	void Start () {
		this.originalPosition = this.transform.position;
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
		rb.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = this.originalPosition + this.transform.right * this.distance * Mathf.Sin(Time.time);
	}
}
