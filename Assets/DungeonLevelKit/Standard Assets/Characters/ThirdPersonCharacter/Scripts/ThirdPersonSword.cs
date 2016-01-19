using UnityEngine;
using UnityStandardAssets.Characters.Enemy;

namespace UnityStandardAssets.Characters.ThirdPerson {
	public class ThirdPersonSword : MonoBehaviour {

		AEnemyCharacter enemyCharacter;
		GameObject enemy;

		void OnTriggerEnter(Collider collision)
		{
			if (collision.gameObject.tag == "Enemy") {
				var hero = transform.root.gameObject;

				var stateInfo =  hero.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

				if (stateInfo.IsName("AttackSlice") || stateInfo.IsName("AttackCleave") || stateInfo.IsName("AttackStab")){

					float distance = Vector3.Distance(collision.gameObject.transform.position, transform.position);

					if (distance < 2) {

						hero.GetComponent<ThirdPersonCharacter> ().PlaySwordSound ();

						enemy = collision.gameObject;
						Invoke ("KillEnemy", 0.6f);
					}
				}
			}
		}

		void KillEnemy(){
			enemyCharacter = enemy.GetComponent<AEnemyCharacter>();
			enemyCharacter.Hurt(1.0f);
		}

		public void toggleCollider(bool state){
			transform.GetComponent<BoxCollider> ().enabled = state;
		}
	}
}