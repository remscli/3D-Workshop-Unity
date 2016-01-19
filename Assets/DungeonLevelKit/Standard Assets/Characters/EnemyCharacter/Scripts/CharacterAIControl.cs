using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.Enemy
{
    [RequireComponent(typeof (NavMeshAgent))]
	[RequireComponent(typeof (AEnemyCharacter))]

    public class CharacterAIControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
		public AEnemyCharacter character { get; private set; } // the character we are controlling
		public Transform target; // target to aim for
		public float closeDistance = 4.6F;
		bool shouldWalk;

        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
			agent = GetComponentInChildren<NavMeshAgent>();
			character = GetComponent<AEnemyCharacter>();

			shouldWalk = false;
			agent.Stop ();

			agent.updatePosition = false;
        }


        // Update is called once per frame
        private void Update()
		{
			if (!agent.enabled)
				return;

			agent.SetDestination(target.position);

			if (target != null && shouldWalk)
			{
				transform.position = agent.nextPosition;
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
				ShouldWalk ();
			}
		}

		void OnTriggerExit(Collider collision) 
		{
			if (agent.enabled && collision.gameObject.name == "ThirdPersonController") {
				ShouldWalk ();
			}
		}
		 
		public void ShouldWalk(){

			if (!agent.enabled)
				return;

			float distance = Vector3.Distance (target.position, transform.position);

			if ( distance > closeDistance) {
				shouldWalk = true;

				agent.Resume ();

			} else {
				shouldWalk = false;

				agent.Stop ();

				transform.LookAt(target.position,Vector3.up);

				character.Fight();
			}
		}
    }
}
