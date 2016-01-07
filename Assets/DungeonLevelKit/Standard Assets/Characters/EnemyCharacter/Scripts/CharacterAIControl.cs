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
		bool isClose;

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
            if (target != null && shouldWalk)
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
			if (collision.gameObject.name == "ThirdPersonController") {
				Debug.Log ("Collision Enter");

				// Get distance and stop enemy if hero is close
				float distance = Vector3.Distance(collision.gameObject.transform.position, transform.position);

				Debug.Log (distance);
				Debug.Log (closeDistance + 1f);

				if (distance > closeDistance + 1f){
					shouldWalk = true;

				} else {
					Debug.Log ("The hero is close to me!");	
					shouldWalk = false;
					agent.Stop ();
					character.Fight();
				}
			}
		}

		void OnTriggerExit(Collider collision) 
		{
			if (collision.gameObject.name == "ThirdPersonController") {
				Debug.Log ("Collision Exit");


				// Get distance and stop enemy if hero is close
				float distance = Vector3.Distance(collision.gameObject.transform.position, transform.position);

				Debug.Log (distance);
				Debug.Log (closeDistance);

				if (distance > closeDistance){
					shouldWalk = true;
					Debug.Log ("The hero is far from me!");	
					agent.Resume ();
				}
			}
		}
    }
}
