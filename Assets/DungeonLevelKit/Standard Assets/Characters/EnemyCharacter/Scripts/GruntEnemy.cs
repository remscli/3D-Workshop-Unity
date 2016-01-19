using UnityEngine;

namespace UnityStandardAssets.Characters.Enemy
{
	public class GruntEnemy : AEnemyCharacter {
		public override void Fight(){
			if(!m_Fighting && m_Life > 0.0f){
				m_Animator.SetFloat ("Forward", 0.0f);

				m_Fighting = true;

				Invoke ("SendSwordPunch", 0.2f);

				Invoke ("Enrage", 1.30f);
			}
		}
	}
}