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
		bool targetSeen;
		bool isClose;

        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
			character = GetComponent<EnemyCharacter>();
			targetSeen = false;
			isClose = false;

	        agent.updateRotation = true;
	        agent.updatePosition = true;
        }


        // Update is called once per frame
        private void Update()
        {
            if (target != null && targetSeen)
            {
                agent.SetDestination(target.position);

				if (isClose) {
					character.Move (Vector3.zero, false, false);
				} else {
					character.Move (agent.desiredVelocity, false, false);
				}
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
			if (collision.gameObject.name == "ThirdPersonController") {
				if (!targetSeen)
					targetSeen = true;

				// Get distance and stop enemy if hero is close
				Vector3 offset = collision.gameObject.transform.position - transform.position;
				float distance = offset.sqrMagnitude;
				if (distance < closeDistance * closeDistance) {
					print ("The hero is close to me!");	
					isClose = true;
					agent.Stop (); // Stop agent's moving
				}
			}
		}

		void OnTriggerExit(Collider collision) 
		{
			if (collision.gameObject.name == "ThirdPersonController") {
				// Get distance and move enemy if hero is close
				Vector3 offset = collision.gameObject.transform.position - transform.position;
				float distance = offset.sqrMagnitude;
				if (distance > closeDistance * closeDistance - 1) {
					print ("The hero is far from me!");	
					isClose = false;
					agent.Resume (); // Resume agent's moving
				}
			}
		}
    }
}
