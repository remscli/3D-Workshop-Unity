using UnityEngine;
using System.Collections;
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
		
		// Update is called once per frame
		void Update () {
			
		}

		void OnCollisionEnter(Collision collision){
			Destroy (gameObject);

			if (collision.collider.name == "ThirdPersonController") {
				print ("hit");
				GameObject hero = GameObject.Find (collision.collider.name);
				ThirdPersonCharacter heroCharacter = hero.GetComponent ("ThirdPersonCharacter") as ThirdPersonCharacter;
				Debug.Log (heroCharacter);
				heroCharacter.Hurt (damages);
			}
		}
	}
}