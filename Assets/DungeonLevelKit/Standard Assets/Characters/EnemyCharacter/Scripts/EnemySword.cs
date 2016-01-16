using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

namespace UnityStandardAssets.Characters.Enemy {
	public class EnemySword : MonoBehaviour {

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

				if (stateInfo.IsName("AttackSlice") || stateInfo.IsName("AttackCleave") || stateInfo.IsName("AttackStab")){

					float distance = Vector3.Distance(collision.gameObject.transform.position, transform.position);

					print (distance);

					if (distance < 2) {
						thirdPerson = collision.gameObject;
						Invoke ("KillThirdPerson", 0.6f);
					}
				}
			}
		}

		void KillThirdPerson(){
			print ("killed");
			thirdPersonCharacter = thirdPerson.GetComponent<ThirdPersonCharacter>();
			thirdPersonCharacter.Hurt(1.0f);
		}

		public void toggleCollider(bool state){
			transform.GetComponent<BoxCollider> ().enabled = state;
		}
	}
}