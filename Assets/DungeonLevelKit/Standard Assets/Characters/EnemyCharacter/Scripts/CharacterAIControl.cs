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
		bool isClose = false;

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
				//Debug.Log (isClose);

				// Get distance and stop enemy if hero is close
				float distance = Vector3.Distance(collision.gameObject.transform.position, transform.position);

				//Debug.Log (distance);

				if (distance > closeDistance && !isClose){
					Debug.Log ("The hero is far from me!");
					//agent.Resume ();
					agent.updatePosition = true;
					character.EndFight();
					shouldWalk = true;

				} else if (distance < closeDistance && !isClose){
					Debug.Log ("The hero is close to me!");	
					//agent.Stop ();
					agent.updatePosition = false;
					character.Fight();
					shouldWalk = false;
					isClose = true;
				}
			}
		}

		void OnTriggerExit(Collider collision) 
		{
			if (agent.enabled && collision.gameObject.name == "ThirdPersonController") {
				//Debug.Log ("Collision Exit");
				//Debug.Log (isClose);
				// Get distance and make enemy walk if hero is far
				float distance = Vector3.Distance(collision.gameObject.transform.position, transform.position);

				//Debug.Log (distance);

				if (distance > closeDistance && isClose){
					Debug.Log ("The hero is far from me!");
					//agent.Resume ();
					agent.updatePosition = true;
					character.EndFight();
					shouldWalk = true;
					isClose = false;
				}
			}
		}
    }
}
