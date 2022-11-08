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
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponDamage = 25f;
        NavMeshAgent navmeshAgent;
        Transform target;
        float timeSinceLastAttack = 0;

        private void Start()
        {
            navmeshAgent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return;
            if (target.GetComponent<Health>() && target.GetComponent<Health>().Dead) return;
            if (Vector3.Distance(transform.position, target.position) <= weaponRange && timeSinceLastAttack >= timeBetweenAttacks)
            {
                timeSinceLastAttack = 0;
                GetComponent<Mover>().Cancel();
                transform.LookAt(target.position);
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
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
            GetComponent<Animator>().SetTrigger("CancelAttack");
        }

        void Hit()
        {
            if (target)
            {
                Health health = target.GetComponent<Health>();
                if (health.Dead) GetComponent<Animator>().SetTrigger("CancelAttack");
                if (health != null) health.TakeDamage(weaponDamage);
            }
        }
    }
}
