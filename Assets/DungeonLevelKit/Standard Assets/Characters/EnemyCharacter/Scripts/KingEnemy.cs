using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace UnityStandardAssets.Characters.Enemy
{
	public class KingEnemy : AEnemyCharacter {
		
		public Slider m_Lifebar_Slider;
		float Start_Life;
		CameraShake cameraShake;

		// Use this for initialization
		protected override void Start () {
			base.Start();
			cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();

			Start_Life = m_Life;
		}

		public override void Fight(){
			if(!m_Fighting && m_Life > 0.0f){
				m_Animator.SetFloat ("Forward", 0.0f);

				m_Fighting = true;

				Invoke ("SendSwordPunch", 0.9f);

				Invoke ("ShakeCamera", 0.9f);

				Invoke ("Enrage", 1.30f);
			}
		}

		void ShakeCamera(){
			cameraShake.Shake();
		}

		public override void UpdateLife(float newLife){
			m_Lifebar_Slider.value = newLife / Start_Life;
		}

		public override void Die(){
			Destroy (m_Lifebar_Slider.gameObject.transform.parent.gameObject);
			Debug.Log (GameObject.Find ("ThirdPersonCharacter"));
			GameObject.Find ("ThirdPersonController").GetComponent<ThirdPersonCharacter> ().GameEnd ("success");
		}
	}
}