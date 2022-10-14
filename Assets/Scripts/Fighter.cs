using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {

        [SerializeField] float weaponRange = 2f;
        NavMeshAgent navmeshAgent;
        Transform target;

        private void Start()
        {
            navmeshAgent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            if (target != null && Vector3.Distance(transform.position, target.position) <= weaponRange)
            {
                navmeshAgent.isStopped = true;
            }
            else
            {
                navmeshAgent.isStopped = false;
                if (target != null) GetComponent<Mover>().MoveTo(target.position);
            }
        }
        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
            navmeshAgent.isStopped = false;
        }
    }
}
