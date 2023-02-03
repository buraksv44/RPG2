using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movment;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour,IAction
    {
        [SerializeField] float timeBetweenAttcaks = 1f;
        [SerializeField] float weaponRange;
         Transform targetObject;
        float timeSinceLastAttack;
        [SerializeField]float weaponDamge=10f;
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            TargetUpdate();
        }

        private void TargetUpdate()
        {
            if (targetObject == null)
            {
                return;
            }

            if (GetIsRange() == false)
            {
                GetComponent<Mover>().MoveTo(targetObject.position);
            }
            else
            {
                AttackMove();
                GetComponent<Mover>().Cancel();
            }
        }

        private void AttackMove()
        {
            if (timeSinceLastAttack > timeBetweenAttcaks)
            {
                GetComponent<Animator>().SetTrigger("attack");
                 timeSinceLastAttack= 0f;
                
            }
            
        }
        void Hit()
        {
            Health health = targetObject.GetComponent<Health>();
            health.TakeDamge(weaponDamge);
        }

        private bool GetIsRange()
        {
            return Vector3.Distance(transform.position, targetObject.position) < weaponRange;
        }

        public void Attack(CombatTarget target)
        {
          GetComponent<ActionScheduler>().StartAction(this);
          targetObject = target.transform;
        }
        public void Cancel()
        {
            targetObject=null;
        }
    }
}

