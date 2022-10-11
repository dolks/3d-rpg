using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
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
        navMeshAgent.destination = point;
    }
}
