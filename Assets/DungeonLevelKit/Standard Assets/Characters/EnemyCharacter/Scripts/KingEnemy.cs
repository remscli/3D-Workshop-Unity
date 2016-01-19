using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.Enemy
{
	public class KingEnemy : AEnemyCharacter {
		
		public Slider m_Lifebar_Slider;
		float Start_Life;

		// Use this for initialization
		protected override void Start () {
			base.Start();

			Start_Life = m_Life;
		}

		public override void Fight(){
			//Debug.Log ("Fight");
			if(!m_Fighting && m_Life > 0.0f){
				//Debug.Log ("Fight");
				m_Animator.SetFloat ("Forward", 0.0f);

				print ("ATTACK");

				m_Fighting = true;

				Invoke ("SendSwordPunch", 0.9f);

				Invoke ("Enrage", 1.30f);
			}
		}

		public override void UpdateLife(float newLife){
			m_Lifebar_Slider.value = newLife / Start_Life;

			if (newLife <= 0.0f) {
				print ("WIN !");
			}
		}

		public override void Die(){
			Destroy (m_Lifebar_Slider);
		}
	}
}