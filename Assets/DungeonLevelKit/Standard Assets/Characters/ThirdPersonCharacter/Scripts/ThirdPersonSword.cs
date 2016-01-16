using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.Enemy;

namespace UnityStandardAssets.Characters.ThirdPerson {
	public class ThirdPersonSword : MonoBehaviour {

		EnemyCharacter enemyCharacter;
		GameObject enemy;

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		void OnTriggerEnter(Collider collision)
		{
			//print (collision.gameObject.name);
			if (collision.gameObject.name == "AIArcherController" 
				|| collision.gameObject.name == "AIWarriorController"
				|| collision.gameObject.name == "AIMageController") {
				var hero = transform.root.gameObject;
				var stateInfo =  hero.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

				if (stateInfo.IsName("AttackSlice") || stateInfo.IsName("AttackCleave") || stateInfo.IsName("AttackStab")){

					float distance = Vector3.Distance(collision.gameObject.transform.position, transform.position);

					print (distance);

					if (distance < 2) {
						enemy = collision.gameObject;
						Invoke ("KillEnemy", 0.6f);
					}
				}
			}
		}

		void KillEnemy(){
			print ("killed");
			enemyCharacter = enemy.GetComponent<EnemyCharacter>();
			enemyCharacter.Hurt(1.0f);
		}

		public void toggleCollider(bool state){
			transform.GetComponent<BoxCollider> ().enabled = state;
		}
	}
}