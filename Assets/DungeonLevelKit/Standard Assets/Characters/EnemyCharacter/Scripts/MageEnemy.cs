using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.Enemy
{
	public class MageEnemy : AEnemyCharacter {
		public override void Fight(){
			//Debug.Log ("Fight");
			if(!m_Fighting && m_Life > 0.0f){
				//Debug.Log ("Fight");
				m_Animator.SetFloat ("Forward", 0.0f);

				print ("ATTACK");

				m_Fighting = true;

				Invoke ("SendParticles", 0.75f);

				Invoke ("Enrage", 1.30f);
			}
		}

		void SendParticles(){
			print ("SEND PARTICULES");
			attackSound.Play ();
			magicWand.GetComponent<EnemyMagicWand>().Play ();
		}
	}
}