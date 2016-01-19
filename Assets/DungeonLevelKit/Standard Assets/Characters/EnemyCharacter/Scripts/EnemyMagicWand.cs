using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace UnityStandardAssets.Characters.Enemy {
	public class EnemyMagicWand : MonoBehaviour {

		public float damages = 0.5f;
		ThirdPersonCharacter thirdPersonCharacter;
		GameObject thirdPerson;
		ParticleSystem particles;

		// Use this for initialization
		void Start () {
			particles = transform.FindChild ("Particle System").GetComponent<ParticleSystem> ();
			particles.Stop ();
		}
			
		public void Play(){
			particles.Play ();
		}

	}
}