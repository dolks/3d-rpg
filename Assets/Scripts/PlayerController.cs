using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using System;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {

        Mover mover;

        private void Start()
        {
            mover = GetComponent<Mover>();
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                InteractWithCombat();
                MoveToCursor();
            }
        }

        private void InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.GetComponent<CombatTarget>() && Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack();
                }
            }
        }

        public void MoveToCursor()
        {
            Ray ray = GetMouseRay();
            RaycastHit hit;
            bool hasHit = Physics.Raycast(ray, out hit);
            if (hasHit)
            {
                mover.MoveTo(hit.point);
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
