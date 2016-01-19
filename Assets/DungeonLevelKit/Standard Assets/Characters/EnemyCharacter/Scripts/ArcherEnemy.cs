using UnityEngine;

namespace UnityStandardAssets.Characters.Enemy
{
	public class ArcherEnemy : AEnemyCharacter {

		public GameObject arrow;

		protected override void Start(){
			base.Start ();

			arrow.SetActive(false);
		}

		public override void Fight(){
			if(!m_Fighting && m_Life > 0.0f){
				m_Animator.SetFloat ("Forward", 0.0f);

				m_Fighting = true;

				Invoke ("SendArrow", 0.75f);

				Invoke ("Enrage", 1.30f);
			}
		}

		void SendArrow(){
			attackSound.Play ();
			GameObject newProjectile;
			newProjectile = Instantiate (arrow, arrow.transform.position, arrow.transform.rotation) as GameObject;
			newProjectile.SetActive (true);
		}
	}
}