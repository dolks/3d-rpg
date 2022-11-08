using UnityEngine;

namespace RPG.Combat
{

    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100f;
        bool dead = false;

        public bool Dead
        {
            get { return dead; }
        }

        public void TakeDamage(float damage)
        {
            if (health - damage < 0)
            {
                health = 0;
                if (!dead) GetComponent<Animator>().SetTrigger("Die");
                dead = true;
            }
            else
            {
                health -= damage;
            }
        }
    }
}