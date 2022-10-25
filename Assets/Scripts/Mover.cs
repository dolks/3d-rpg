using UnityEngine;
using UnityEngine.AI;
using RPG.Core;
namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] Transform target;
        NavMeshAgent navMeshAgent;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                navMeshAgent.isStopped = true;
            }
            if (Input.GetMouseButton(0))
            {
                navMeshAgent.isStopped = false;
            }
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
        }

        public void MoveTo(Vector3 point)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            navMeshAgent.destination = point;
        }

        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }

    }
}
