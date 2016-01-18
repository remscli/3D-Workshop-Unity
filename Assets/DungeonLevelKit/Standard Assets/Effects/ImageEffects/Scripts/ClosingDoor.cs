using UnityEngine;
using System.Collections;

public class ClosingDoor : MonoBehaviour {

	Rigidbody m_Rigidbody;
	AudioSource closeSound;

	void Start() {
		m_Rigidbody = GetComponent<Rigidbody>();
		closeSound = GetComponent<AudioSource>();
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "ThirdPersonController") {
			m_Rigidbody.useGravity = true;
			closeSound.Play ();
		}
	}
}
