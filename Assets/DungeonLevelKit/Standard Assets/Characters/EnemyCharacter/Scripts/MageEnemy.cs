using UnityEngine;

namespace UnityStandardAssets.Characters.Enemy
{
	public class MageEnemy : AEnemyCharacter {
		public override void Fight(){
			if(!m_Fighting && m_Life > 0.0f){
				m_Animator.SetFloat ("Forward", 0.0f);

				m_Fighting = true;

				Invoke ("SendParticles", 0.75f);

				Invoke ("Enrage", 1.30f);
			}
		}

		void SendParticles(){
			attackSound.Play ();
			magicWand.GetComponent<EnemyMagicWand>().Play ();
		}
	}
}