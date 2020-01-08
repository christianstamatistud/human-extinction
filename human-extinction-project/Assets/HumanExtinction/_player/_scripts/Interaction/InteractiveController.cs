using UnityEngine;
using NaughtyAttributes;
using System;

namespace CS
{

    public class InteractiveController : MonoBehaviour
    {
        InputManager m_inputManager;

        [BoxGroup("Ray Settings")] [SerializeField] Camera m_cam;
        [BoxGroup("Ray Settings")] [SerializeField] float m_rayDistance;
        [BoxGroup("Ray Settings")] [SerializeField] float m_sphereRadius;


        public LayerMask m_interactableLayer;
        private InteractiveObject _interactiveObject;

        private void Awake()
        {
            m_inputManager = FindObjectOfType<InputManager>();
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
            Ray _ray = new Ray(m_cam.transform.position, m_cam.transform.forward);
            RaycastHit _hitInfo;

            bool _hitSomething = Physics.SphereCast(_ray, m_sphereRadius, out _hitInfo, m_rayDistance, m_interactableLayer);

            if (_hitSomething)
            {
                _interactiveObject = _hitInfo.transform.GetComponent<InteractiveObject>();
            }
            Debug.DrawRay(_ray.origin, _ray.direction * m_rayDistance, _hitSomething ? Color.green : Color.red);
        }

        void Interact()
        {
            if (_interactiveObject != null)
            {
                _interactiveObject.OnAction();

            }
        }
    }

}

