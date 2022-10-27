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

        [SerializeField] float weaponRange = 4f;
        NavMeshAgent navmeshAgent;
        Transform target;

        private void Start()
        {
            navmeshAgent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            if (target == null) return;
            if (Vector3.Distance(transform.position, target.position) <= weaponRange)
            {
                GetComponent<Mover>().Cancel();
                GetComponent<Animator>().SetTrigger("Attack");
            }
            else
            {
                if (target != null) GetComponent<Mover>().MoveTo(target.position);
            }
        }
        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            print("setting target to" + combatTarget.transform);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }

        void Hit()
        {
        }
    }
}
