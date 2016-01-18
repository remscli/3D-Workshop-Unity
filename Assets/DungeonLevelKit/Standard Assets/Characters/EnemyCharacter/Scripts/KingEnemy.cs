using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.Enemy
{
	public class KingEnemy : MonoBehaviour {

		float m_Life;
		GameObject m_Lifebar;
		Slider m_Lifebar_Slider;

		// Use this for initialization
		void Start () {
			m_Lifebar =  GameObject.Find("King_Lifebar");
			m_Lifebar_Slider = m_Lifebar.GetComponent<Slider> ();
			m_Life = GetComponent<EnemyCharacter> ().m_Life;
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void UpdateLife(float newLife){
			m_Lifebar_Slider.value = newLife / m_Life;
		}

		public void Die(){
			Destroy (m_Lifebar);
		}
	}
}