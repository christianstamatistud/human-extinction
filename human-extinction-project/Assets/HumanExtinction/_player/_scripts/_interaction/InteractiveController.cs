﻿using UnityEngine;
using NaughtyAttributes;
using System;

namespace CS
{

    public class InteractiveController : MonoBehaviour
    {
        InputManager m_inputManager;

         Camera m_camera;
        [BoxGroup("Ray Settings")] [SerializeField] float m_rayDistance;
        [BoxGroup("Ray Settings")] [SerializeField] float m_sphereRadius;
        [BoxGroup("Ray Settings")] [SerializeField] LayerMask m_interactableLayer;
        [Space(10)]
        //Show Selected Objects
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] public InteractiveObject m_interactiveObject;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] public GameObject selectedObjectRoot;
        private Rigidbody m_Rigidbody;



        private void Awake()
        {
            m_inputManager = FindObjectOfType<InputManager>();
            m_camera = GetComponentInChildren<Camera>();
        }

        private void OnEnable()
        {
            m_inputManager.Interacting += Interact;
        }

        private void OnDisable()
        {
            m_inputManager.Interacting -= Interact;

        }



        private void Update()
        {
            CheckForInteractable();
        }

        private void CheckForInteractable()
        {
            Ray _ray = new Ray(m_camera.transform.position, m_camera.transform.forward);
            RaycastHit _hitInfo;

            bool _hitSomething = Physics.SphereCast(_ray, m_sphereRadius, out _hitInfo, m_rayDistance, m_interactableLayer);

            if (_hitSomething)
            {

                m_Rigidbody = _hitInfo.transform.GetComponent<Rigidbody>();
                //get INTERACTIVE SCRIPT
                m_interactiveObject = m_Rigidbody.GetComponentInChildren<InteractiveObject>();
                //get object root
                GameObject hitObject = m_Rigidbody.transform.gameObject;
                SelectedObject(hitObject);

            }
            else
            {
                ClearSelection();

            }
            Debug.DrawRay(_ray.origin, _ray.direction * m_rayDistance, _hitSomething ? Color.green : Color.red);
        }


        void SelectedObject(GameObject obj)
        {
            if(selectedObjectRoot != null)
            {
                if (obj = selectedObjectRoot)
                    return;

                ClearSelection();
            }

            selectedObjectRoot = obj;

            //Renderer[] rs = selectedObjectRoot.GetComponentsInChildren<Renderer>();
            //foreach (Renderer r in rs)
            //{
            //    Material m = r.material;
            //    m.SetColor("_BaseColor", Color.green);

            //    print("Set Color");
            //}

        }

        void ClearSelection()
        {
            if (selectedObjectRoot == null)
                return;

            //Renderer[] rs = selectedObjectRoot.GetComponentsInChildren<Renderer>();
            //foreach (Renderer r in rs)
            //{
            //    Material m = r.material;
            //    m.SetColor("_BaseColor", Color.white);

            //    print("Set Color Default");
            //}

            selectedObjectRoot = null;
            m_interactiveObject = null;
        }


        void Interact()
        {
            if (m_interactiveObject != null)
            {
                m_interactiveObject.OnAction();

            }
        }
    }

}

