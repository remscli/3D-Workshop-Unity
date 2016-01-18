using UnityEngine;
using System.Collections;

public class ClosingDoor : MonoBehaviour {

	Rigidbody m_Rigidbody;

	void Start() {
		m_Rigidbody = GetComponent<Rigidbody>();
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "ThirdPersonController") {
			m_Rigidbody.useGravity = true;
		}
	}
}
