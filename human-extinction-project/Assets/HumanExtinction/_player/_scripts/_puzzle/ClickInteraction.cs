using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CS
{
    public class ClickInteraction : MonoBehaviour
    {
        public Camera m_camera;



        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                RaycastHit hit;
                Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    OrbitMotion om;
                    om = hit.transform.gameObject.GetComponent<OrbitMotion>();
                    om.ToggleOrbitMotion();

                }

            }
        }
    }

}

