using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace UnityStandardAssets.Characters.Enemy
{
	public class Projectile : MonoBehaviour {

		public int speed = 1200;
		public float damages = 0.5f;
		Rigidbody projectileBody;

		// Use this for initialization
		void Start () {
			projectileBody = gameObject.GetComponent<Rigidbody> ();
			projectileBody.AddRelativeForce (Vector3.forward * speed);
		}
			
		void OnCollisionEnter(Collision collision){
			Destroy (gameObject);

			if (collision.collider.name == "ThirdPersonController") {
				GameObject hero = GameObject.Find (collision.collider.name);
				ThirdPersonCharacter heroCharacter = hero.GetComponent ("ThirdPersonCharacter") as ThirdPersonCharacter;
				Debug.Log (heroCharacter);
				heroCharacter.Hurt (damages);
			}
		}
	}
}