using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.Enemy
{
    [RequireComponent(typeof (NavMeshAgent))]
	[RequireComponent(typeof (EnemyCharacter))]

    public class CharacterAIControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
		public EnemyCharacter character { get; private set; } // the character we are controlling
		public Transform target; // target to aim for
		public float closeDistance = 4.6F;
		bool shouldWalk;

        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
			character = GetComponent<EnemyCharacter>();
			shouldWalk = false;

	        agent.updateRotation = true;
	        agent.updatePosition = true;
        }


        // Update is called once per frame
        private void Update()
        {
			if (agent.enabled && target != null && shouldWalk)
            {
				agent.SetDestination(target.position);
				character.Move (agent.desiredVelocity, false, false);
            }
            else
            {
                // We still need to call the character's move function, but we send zeroed input as the move param.
                character.Move(Vector3.zero, false, false);
            }

        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }

		void OnTriggerEnter(Collider collision) 
		{
			if (agent.enabled && collision.gameObject.name == "ThirdPersonController") {
				//Debug.Log ("Collision Enter");

				ShouldWalk ();
			}
		}

		void OnTriggerExit(Collider collision) 
		{
			if (agent.enabled && collision.gameObject.name == "ThirdPersonController") {
				//Debug.Log ("Collision Exit");

				ShouldWalk ();
			}
		}
		 
		public void ShouldWalk(){
			float distance = Vector3.Distance (target.position, transform.position);

			if ( distance > closeDistance) {
				Debug.Log ("The hero is far from me!");
				//agent.Resume ();
				agent.updatePosition = true;
				shouldWalk = true;

			} else {
				Debug.Log ("The hero is close to me!");	
				//agent.Stop ();
				agent.updatePosition = false;
				shouldWalk = false;

				character.Fight();
			}
		}
    }
}
