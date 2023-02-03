using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace RPG.Combat
{

    public class Health : MonoBehaviour
    {
        [SerializeField] GameObject enmyEffct;
        [SerializeField] UnityEngine.UI.Image enemy,enemy1;
        [SerializeField] float  health = 100f;
        float healthint = 100f;
        bool ÝsDead = false;
        float time=2f;
        
        void Start()
        {
           healthint = health;
        }
        public void TakeDamge(float damage)
        {
            health=Mathf.Max(health - damage, 0);
            enemy.fillAmount=health/healthint;
            if (enemy.fillAmount ==0)
            {
                Die();
            }



        }

        private void Die()
        {
            if (ÝsDead == true)
            {
                return;
            }
            ÝsDead = true;
            GetComponent<Animator>().SetTrigger("die");
            Destroy(gameObject, time);
            Destroy(enemy1, time);
            Invoke("EnemyEffect",1.9f);
        }

        private void EnemyEffect()
        {
            Vector3 EnemyPos=gameObject.transform.position;
            Instantiate(enmyEffct,EnemyPos,Quaternion.identity);
           
        }
    }

}
