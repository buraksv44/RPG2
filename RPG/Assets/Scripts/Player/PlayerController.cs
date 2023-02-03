using RPG.Combat;
using RPG.Movment;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.PlayerCont
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] GameObject obje;
        
        void Update()
        {
            AtcakMoveStatus();
            
        }

        private void AtcakMoveStatus()
        {
            if (InteractWithCombat() == true)
            {
                return;
            }
            if (Actionmethod() == true)
            {
                return;
            }
        }

        bool InteractWithCombat()
        {
            
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();

                if (target == null)
                {
                    continue;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    
                    GetComponent<Fighter>().Attack(target);
                }
                return true;  
            }
            return false;
        }
        bool Actionmethod()
        { 
           RaycastHit hit;
            bool obje1 = Physics.Raycast(GetMouseRay(), out hit);
            if (obje1 == true)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StarMoveAction(hit.point);
                    Vector3 LastPos = hit.point;
                    LastPos.y = 0.35f;
                    Instantiate(obje, LastPos, Quaternion.identity);

                }

                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        
    }
}
