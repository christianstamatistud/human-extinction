using UnityEngine;
using NaughtyAttributes;
using TMPro;
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
        [BoxGroup("DEBUG")] [SerializeField] [HideInInspector] public InteractiveObject m_interactiveObject;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] public GameObject selectedObjectRoot;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] public GameObject currentObject;

        SelectionController m_selectionController;

        private void OnEnable()
        {
            m_inputManager.playerInteracting += Interact;
            m_inputManager.leftMousePressed += AbsorbThrow;
        }

        private void OnDisable()
        {

            m_inputManager.playerInteracting -= Interact;
            m_inputManager.leftMousePressed -= AbsorbThrow;


        }


        [BoxGroup("DEBUG")] [SerializeField] [HideInInspector] public GameObject ItemHolder;
        [BoxGroup("DEBUG")] [SerializeField] [ReadOnly] public bool hasItem;


        private Rigidbody m_Rigidbody;



        private void Awake()
        {
            m_inputManager = FindObjectOfType<InputManager>();
            m_camera = GetComponentInChildren<Camera>();
            ItemHolder = GameObject.FindGameObjectWithTag("ItemHolder");
            m_selectionController = FindObjectOfType<SelectionController>();
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

                if (m_interactiveObject.IsInteractable)
                {
                    m_selectionController.key = m_interactiveObject.key;
                    m_selectionController.m_name = m_interactiveObject.m_name;
                }

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
            if (m_interactiveObject != null && m_interactiveObject.IsInteractable)
            {
                m_interactiveObject.OnInteraction();
            }
        }

        void AbsorbThrow()
        {
            // Drag Object
            if (m_interactiveObject != null && !hasItem)
            {
                m_interactiveObject.OnDrag();
            }// Call Drag on Current Object
            else if (currentObject != null)
            {
                currentObject.GetComponentInChildren<InteractiveObject>().OnDrag();
            }

        }



    }

}

