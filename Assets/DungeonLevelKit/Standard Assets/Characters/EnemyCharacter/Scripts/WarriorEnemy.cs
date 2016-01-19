using UnityEngine;

namespace UnityStandardAssets.Characters.Enemy
{
	public class WarriorEnemy : AEnemyCharacter {
		public override void Fight(){
			if(!m_Fighting && m_Life > 0.0f){
				m_Animator.SetFloat ("Forward", 0.0f);

				m_Fighting = true;

				Invoke ("SendSwordPunch", 0.3f);

				Invoke ("Enrage", 1.30f);
			}
		}
	}
}