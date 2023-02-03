 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform player;
        float speed=5;
        float Scorllspeed = 5;

      
        void Update()
        {
            Cameras();
        }
        void Cameras()
        {
            transform.position = player.position;
            if (Input.GetMouseButton(1))
            {
                transform.eulerAngles += speed * new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
            }
            if (Camera.main.orthographic)
            {
                Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * Scorllspeed;
            }
            else
            {
                Camera.main.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * Scorllspeed;
            }

        }
    }

}
