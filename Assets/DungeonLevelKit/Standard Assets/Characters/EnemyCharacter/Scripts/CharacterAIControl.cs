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
		bool targetSeen;

        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
			character = GetComponent<EnemyCharacter>();
			targetSeen = false;

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        // Update is called once per frame
        private void Update()
        {
            if (target != null && targetSeen)
            {
                agent.SetDestination(target.position);

				
				
                // use the values to move the character
                character.Move(agent.desiredVelocity, false, false);
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
			if (collision.gameObject.name == "ThirdPersonController")
				targetSeen = true;
		}
    }
}
