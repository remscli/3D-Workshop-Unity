using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

namespace UnityStandardAssets.Characters.Enemy {
	public class EnemySword : MonoBehaviour {

		public float damages = 0.5f;
		ThirdPersonCharacter thirdPersonCharacter;
		GameObject thirdPerson;

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}

		void OnTriggerEnter(Collider collision)
		{
			//print (collision.gameObject.name);
			if (collision.gameObject.name == "ThirdPersonController") {
				var enemy = transform.root.gameObject;
				var stateInfo =  enemy.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

				if (stateInfo.IsName("Fighting")){

					float distance = Vector3.Distance(collision.gameObject.transform.position, transform.position);

					if (distance < 2) {
						thirdPerson = collision.gameObject;
						HurtThirdPerson ();
					}
				}
			}
		}

		void HurtThirdPerson(){
			print ("hero hurted");
			print (damages);
			thirdPersonCharacter = thirdPerson.GetComponent<ThirdPersonCharacter>();
			thirdPersonCharacter.Hurt(damages);
		}

		public void toggleCollider(bool state){
			transform.GetComponent<BoxCollider> ().enabled = state;
		}
	}
}