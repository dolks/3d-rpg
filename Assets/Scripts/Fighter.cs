using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
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
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
            navmeshAgent.isStopped = false;
        }
    }
}
